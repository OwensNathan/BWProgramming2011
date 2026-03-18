using System;
using System.Collections.Generic;

public class TowerOfDefense
{
    public static void Main()
    {
        // Input format:
        // n
        // for each round:
        // r c
        // k
        // k lines: path coordinates (row col) including start (0,0) and end (r-1,c-1)
        // t
        // t lines: tower coordinates (row col)
        // h
        // Output per round: "PASSED" if enemy makes it through (hp > 0 after last position), else "FAILED".

        if (!int.TryParse(Console.ReadLine(), out int rounds)) return;

        for (int round = 0; round < rounds; round++)
        {
            string? rcLine = ReadNonEmptyLine();
            if (rcLine == null) return;
            var rc = rcLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int r = int.Parse(rc[0]);
            int c = int.Parse(rc[1]);

            int k = int.Parse(ReadNonEmptyLine()!);
            var path = new List<(int row, int col)>(k);
            for (int i = 0; i < k; i++)
            {
                var parts = ReadNonEmptyLine()!.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                path.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            int t = int.Parse(ReadNonEmptyLine()!);
            var towers = new List<(int row, int col)>(t);
            for (int i = 0; i < t; i++)
            {
                var parts = ReadNonEmptyLine()!.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                towers.Add((int.Parse(parts[0]), int.Parse(parts[1])));
            }

            int hp = int.Parse(ReadNonEmptyLine()!);

            // Precompute damage per path cell:
            // For each tower, it shoots once for each adjacent path block (including diagonals).
            // Equivalent simulation: when enemy is on a path cell P, the tower shoots enemy
            // (# of path cells adjacent to tower) times IF P is one of those adjacent path cells.
            // So each adjacency (tower <-> pathCell) contributes +1 damage every time enemy stands on that pathCell.

            int[] damagePerStep = new int[path.Count];

            // Map path cell -> index for O(1) lookup
            var pathIndex = new Dictionary<(int row, int col), int>(path.Count);
            for (int i = 0; i < path.Count; i++)
                pathIndex[path[i]] = i;

            // For each tower, add +1 to damage for each adjacent path cell it touches.
            foreach (var tower in towers)
            {
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        if (dr == 0 && dc == 0) continue;
                        var neighbor = (tower.row + dr, tower.col + dc);
                        if (pathIndex.TryGetValue(neighbor, out int idx))
                        {
                            damagePerStep[idx] += 1;
                        }
                    }
                }
            }

            bool failed = false;
            for (int i = 0; i < path.Count; i++)
            {
                hp -= damagePerStep[i];
                if (hp < 0)
                {
                    failed = true;
                    break;
                }
            }

            Console.WriteLine(failed ? "FAILED" : "PASSED");
        }
    }

    private static string? ReadNonEmptyLine()
    {
        string? line;
        do
        {
            line = Console.ReadLine();
            if (line == null) return null;
        } while (line.Length == 0);
        return line;
    }
}