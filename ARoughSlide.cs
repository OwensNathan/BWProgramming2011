using System;
using System.Collections.Generic;

public class Program
{
    sealed class FastScanner
    {
        private readonly Queue<string> _q = new Queue<string>();

        public string Next()
        {
            while (_q.Count == 0)
            {
                string? line = Console.ReadLine();
                if (line == null) return null!; // EOF
                foreach (var part in line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
                    _q.Enqueue(part);
            }
            return _q.Dequeue();
        }

        public int NextInt() => int.Parse(Next());
    }

    static int SolveCase(int Fn, int Fg, int M, List<(int len, int mu)> sections)
    {
        int k = sections.Count;
        int[] ends = new int[k];
        int totalLen = 0;
        for (int i = 0; i < k; i++)
        {
            totalLen += sections[i].len;
            ends[i] = totalLen;
        }

        int MuAt(int distance)
        {
            for (int i = 0; i < k; i++)
                if (distance < ends[i])
                    return sections[i].mu;
            return sections[k - 1].mu;
        }

        int t = 0, v = 0, d = 0;

        while (true)
        {
            if (d > totalLen) return t;

            int mu = MuAt(d);

            int F = Fg - mu * Fn; // friction opposes motion
            int a = F / M;        // integer per problem statement

            int aHalf = a / 2;

            int vAfterHalf = v + aHalf;
            d += vAfterHalf;

            v = vAfterHalf + (a - aHalf);

            t++;
        }
    }

    public static void Main()
    {
        var fs = new FastScanner();

        // If no input at all, exit.
        string first = fs.Next();
        if (first == null) return;

        int n = int.Parse(first);
        var output = new List<string>(n);

        for (int caseNum = 1; caseNum <= n; caseNum++)
        {
            int Fn = fs.NextInt();
            int Fg = fs.NextInt();
            int M  = fs.NextInt();

            int k = fs.NextInt();
            var sections = new List<(int len, int mu)>(k);
            for (int i = 0; i < k; i++)
            {
                int l  = fs.NextInt();
                int mu = fs.NextInt();
                sections.Add((l, mu));
            }

            int ans = SolveCase(Fn, Fg, M, sections);
            output.Add($"Case {caseNum}: {ans}");
        }

        Console.WriteLine(string.Join("\n", output));
    }
}
