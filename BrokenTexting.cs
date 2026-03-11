using System;
using System.Collections.Generic;

public class HelloWorld
{
    static Dictionary<string, char> mapping = new Dictionary<string, char>()
    {
        {"2",'a'}, {"22",'b'}, {"222",'c'},
        {"3",'d'}, {"33",'e'}, {"333",'f'},
        {"4",'g'}, {"44",'h'}, {"444",'i'},
        {"5",'j'}, {"55",'k'}, {"555",'l'},
        {"6",'m'}, {"66",'n'}, {"666",'o'},
        {"7",'p'}, {"77",'q'}, {"777",'r'}, {"7777",'s'},
        {"8",'t'}, {"88",'u'}, {"888",'v'},
        {"9",'w'}, {"99",'x'}, {"999",'y'}, {"9999",'z'}
    };

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
                    j++;

                string seq = input.Substring(start, j - start);
                if (mapping.ContainsKey(seq))
                    output += mapping[seq];
                else
                    output += "?";
            }
        }

        Console.WriteLine(output);
    }
}
