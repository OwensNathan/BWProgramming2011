using System;

public class Program
{
    private static int HexVal(char c)
    {
        if (c >= '0' && c <= '9') return c - '0';
        // input guaranteed uppercase A-F
        return 10 + (c - 'A');
    }

    public static void Main()
    {
        string? line = Console.ReadLine();
        if (line == null) return;

        int n = int.Parse(line.Trim());

        for (int caseIndex = 0; caseIndex < n; caseIndex++)
        {
            int k = int.Parse(Console.ReadLine()!.Trim());
            string lockHex = Console.ReadLine()!.Trim(); // exactly 6 hex digits

            string? foundKey = null;

            for (int i = 0; i < k; i++)
            {
                string keyHex = Console.ReadLine()!.Trim(); // exactly 6 hex digits

                // If we already found a key, still need to consume input but can skip checking.
                if (foundKey != null) continue;

                bool ok = true;
                for (int pos = 0; pos < 6; pos++)
                {
                    int sum = HexVal(lockHex[pos]) + HexVal(keyHex[pos]);
                    if (sum != 15) // 0xF
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok) foundKey = keyHex;
            }

            if (foundKey != null)
                Console.WriteLine($"UNLOCKED BY KEY {foundKey}");
            else
                Console.WriteLine("NOT UNLOCKED");
        }
    }
}
