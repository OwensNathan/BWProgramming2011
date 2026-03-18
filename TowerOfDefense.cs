using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());
        
        public string[] rowCol = Console.ReadLine()!.Split(' ');

        public int[,] board = new int[int.Parse(rowCol[0]), int.Parse(rowCol[1])];
        
        int moveNumber = int.Parse(Console.ReadLine());
        
        int[,] moves = new int[moveNumber,moveNumber];
        for(int i = 0; i < moveNumber; i++)
        {
            string[] rowCol2 = Console.ReadLine()!.Split(' ');
            moves[int.Parse(rowCol2[0]), int.Parse(rowCol2[1])] = 1;
        }
        
        int towerNumber = int.Parse(Console.ReadLine());
        int[,] towers = new int[towerNumber, towerNumber];
        for(int i = 0; i < towerNumber; i++)
        {
            string[] rowCol2 = Console.ReadLine()!.Split(' ');
            towers[int.Parse(rowCol2[0]), int.Parse(rowCol2[1])] = 2;
        }
        
        int health = int.Parse(Console.ReadLine());
        
        int[,] damageSpots = DAMAGE(towers, moves);
    }
    
    public int[,] DAMAGE(location, path)
    {
        int[,] damageLocations = [rowCol[0]+1, rowCol[1]+1];
        for(int i = 0; i < rowCol[0]=1; i++)
        {
            
        }
        return damageLocations;
    }
}
