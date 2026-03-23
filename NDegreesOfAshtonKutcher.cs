using System;
using System.Collections.Generic;

public class Program
{
    private const string Ashton = "@aplusk";

    public static void Main()
    {
        string? first = Console.ReadLine();
        if (first == null) return;

        int t = int.Parse(first.Trim());

        for (int caseNum = 1; caseNum <= t; caseNum++)
        {
            int p = int.Parse(ReadNonEmptyLine().Trim());

            var names = new List<string>(p);
            var idOf = new Dictionary<string, int>(StringComparer.Ordinal);

            // Store raw relationships until all IDs are known
            var followsTokens = new List<List<string>>(p);
            var mentionsTokens = new List<List<string>>(p);

            int targetId = -1;
            int ashtonId = -1;

            for (int i = 0; i < p; i++)
            {
                string user = ReadNonEmptyLine().Trim();
                names.Add(user);
                idOf[user] = i;

                if (i == 0) targetId = i;
                if (user == Ashton) ashtonId = i;

                // follows line
                var followLine = ReadNonEmptyLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int f = int.Parse(followLine[0]);
                var flist = new List<string>(f);
                for (int j = 0; j < f; j++) flist.Add(followLine[j + 1]);
                followsTokens.Add(flist);

                // mentions line
                var mentionLine = ReadNonEmptyLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int m = int.Parse(mentionLine[0]);
                var mlist = new List<string>(m);
                for (int j = 0; j < m; j++) mlist.Add(mentionLine[j + 1]);
                mentionsTokens.Add(mlist);
            }

            // Build adjacency list with weights
            var adj = new List<List<(int to, int w)>>(p);
            for (int i = 0; i < p; i++) adj.Add(new List<(int, int)>());

            for (int i = 0; i < p; i++)
            {
                // Follow edges cost 1
                foreach (var v in followsTokens[i])
                {
                    if (idOf.TryGetValue(v, out int to))
                        adj[i].Add((to, 1));
                }

                // Mention edges cost 2
                foreach (var v in mentionsTokens[i])
                {
                    if (idOf.TryGetValue(v, out int to))
                        adj[i].Add((to, 2));
                }
            }

            int answer = Dijkstra(adj, ashtonId, targetId);

            if (answer >= 0)
                Console.WriteLine($"Case {caseNum}: {answer}");
            else
                Console.WriteLine($"Case {caseNum}: No connection");
        }
    }

    // Dijkstra for nonnegative weights (1 and 2)
    private static int Dijkstra(List<List<(int to, int w)>> adj, int start, int target)
    {
        if (start < 0 || target < 0) return -1;

        int n = adj.Count;
        const int INF = int.MaxValue / 4;
        var dist = new int[n];
        Array.Fill(dist, INF);
        dist[start] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out int d);
            if (d != dist[u]) continue; // stale
            if (u == target) return d;

            foreach (var (v, w) in adj[u])
            {
                int nd = d + w;
                if (nd < dist[v])
                {
                    dist[v] = nd;
                    pq.Enqueue(v, nd);
                }
            }
        }

        return dist[target] >= INF ? -1 : dist[target];
    }

    private static string ReadNonEmptyLine()
    {
        string? s;
        do
        {
            s = Console.ReadLine();
            if (s == null) return "";
        } while (s.Length == 0);
        return s;
    }
}
