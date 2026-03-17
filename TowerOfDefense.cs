using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());
        
        string[] rowCol = Console.ReadLine()!.Split(' ');

        int[,] board = new int[int.Parse(rowCol[0]), int.Parse(rowCol[1])];
        
        int moveNumber = int.Parse(Console.ReadLine());
        
        int[,] moves = new int[moveNumber,moveNumber];
        for(int i = 0; i < moveNumber; i++)
        {
            for(int j = 0; j < moveNumber; j++)
            {
                string[] rowCol = Console.ReadLine()!.Split(' ');
                
                moves[i,j] = [int.Parse(rowCol[0]), int.Parse(rowCol[1])];
            }
        }
    }
}
