using System;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int rows = rowCol[0];
            int columns = rowCol[1];
            byte[][] matrix = new byte[rows][];           
                                                          
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="stop")
                {
                    break;
                }
                string[] data = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int entrance = int.Parse(data[0]);
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);

                int steps = Math.Abs(entrance - row) + 1;   
                if (matrix[row] == null)                    
                {
                    matrix[row] = new byte[columns];        
                }

                if (matrix[row][col] == 0)
                {
                    matrix[row][col] = 1;
                    steps += col;                          
                    Console.WriteLine(steps);
                }
                else
                {
                    int cnt = 1;                            
                    while (true)
                    {
                        int lowerCell = col - cnt;
                        int upperCell = col + cnt;

                        if (lowerCell < 1 && upperCell > columns - 1)  
                        {
                            Console.WriteLine($"Row {row} full");
                            break;
                        }
                        if (lowerCell > 0 && matrix[row][lowerCell] == 0)      
                        {                                                       
                            matrix[row][lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (upperCell < columns && matrix[row][upperCell] == 0) 
                        {                                                        
                            matrix[row][upperCell] = 1;
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        cnt++;
                    }
                }
            }
        }
    }
}
