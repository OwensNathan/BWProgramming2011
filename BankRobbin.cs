using System;
using System.Collections.Generic;

public class program
{
  public static void Main(String[] args)
  {
    int[] numLocks = new int[(int) System.ReadLine()];
    int[] numKeys = new int[(int) System.ReadLine()];
    String Lock = System.ReadLine();
    String[][] possible = new String[numLocks][numKeys];
    for(int i = 0; i < numLocks; i++)
    {
      for(int j = 0; j < numKeys; j++)
      {
      possible[i][j] = System.ReadLine();
      }
    }
    
  }

}
