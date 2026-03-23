// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        long num = int.Parse(Console.ReadLine());
        long startNum = num;
        long ans = 0;
        while(num != 1)
        {
            if(num % 2 ==0)
            {
                num = num/2;
                ans++;
            }
            else
            {
                num = 3*num+1;
                ans = 0;
            }
        }
        Console.WriteLine ($"CC({startNum})={Math.Pow(2,ans)}");
    }
}
