using System;

public class HelloWorld
{
    // Enum where each key sequence directly equals the character
    enum Keypad
    {
        K2 = 'a', K22 = 'b', K222 = 'c',
        K3 = 'd', K33 = 'e', K333 = 'f',
        K4 = 'g', K44 = 'h', K444 = 'i',
        K5 = 'j', K55 = 'k', K555 = 'l',
        K6 = 'm', K66 = 'n', K666 = 'o',
        K7 = 'p', K77 = 'q', K777 = 'r', K7777 = 's',
        K8 = 't', K88 = 'u', K888 = 'v',
        K9 = 'w', K99 = 'x', K999 = 'y', K9999 = 'z'
    }

    public static void Main()
    {
        string input = Console.ReadLine();
        string output = "";

        int j = 0;
        while (j < input.Length)
        {
            if (input[j] == ' ')
            {
                j++;
            }
            else if (input[j] == '#')
            {
                output += " ";
                j++;
            }
            else
            {
                char c = input[j];
                int start = j;

                while (j < input.Length && input[j] == c)
                {
                    j++;
                }

                string seq = input.Substring(start, j - start);
                string enumName = "K" + seq;

                if (Enum.TryParse(enumName, out Keypad key))
                    output += (char)key;   // enum value already equals the letter
                else
                    output += "?";
            }
        }

        Console.WriteLine(output);
    }
}
