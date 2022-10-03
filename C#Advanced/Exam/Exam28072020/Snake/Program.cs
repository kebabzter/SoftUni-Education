using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            int rowS = 0;
            int colS = 0;
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row,col]=='S')
                    {
                        rowS = row;
                        colS = col;
                    }
                }
            }

            int food = 0;
            bool isOver = false;

            while (true)
            {
                string command = Console.ReadLine();
                int newRow = MoveRow(rowS,command);
                int newCol = MoveCol(colS,command);
                matrix[rowS, colS] = '.';

                if (!IsPositionValid(newRow,newCol,n,n))
                {
                    isOver = true;
                    break;
                }

                rowS = newRow;
                colS = newCol;

                if (matrix[rowS,colS]=='*')
                {
                    food++;
                }
                if (food==10)
                {
                    matrix[rowS, colS] = 'S';
                    break;
                }

                if (matrix[rowS, colS] == 'B')
                {
                    for (int r = 0; r < n; r++)
                    {
                        for (int c = 0; c < n; c++)
                        {
                            if (matrix[r, c] == 'B' && r != rowS && c != colS)
                            {
                                matrix[rowS, colS] = '.';
                                rowS = r;
                                colS = c;
                            }
                        }
                    }
                }
             
            }

            if (isOver)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
