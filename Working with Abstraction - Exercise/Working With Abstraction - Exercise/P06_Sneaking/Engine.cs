using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        static char[][] room;
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            FillMatrix(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] samsPosition = FindSamParameters();
            int samsRow = samsPosition[0];
            int samsCol = samsPosition[1];

            for (int i = 0; i < moves.Length; i++)
            {
                EnemiesMovement();

                int[] enemyCoordinates = GetEnemyCoordinates(samsPosition);

                if (samsPosition[1] < enemyCoordinates[1] && room[enemyCoordinates[0]][enemyCoordinates[1]] == 'd' && enemyCoordinates[0] == samsPosition[0])
                {
                    room[samsPosition[0]][samsPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samsPosition[0]}, {samsPosition[1]}");

                    PrintMatrix();
                }
                else if (enemyCoordinates[1] < samsPosition[1] && room[enemyCoordinates[0]][enemyCoordinates[1]] == 'b' && enemyCoordinates[0] == samsPosition[0])
                {
                    room[samsPosition[0]][samsPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samsPosition[0]}, {samsPosition[1]}");

                    PrintMatrix();
                }


                room[samsPosition[0]][samsPosition[1]] = '.';

                switch (moves[i])
                {
                    case 'U':
                        samsPosition[0]--;
                        break;
                    case 'D':
                        samsPosition[0]++;
                        break;
                    case 'L':
                        samsPosition[1]--;
                        break;
                    case 'R':
                        samsPosition[1]++;
                        break;
                    default:
                        break;
                }

                room[samsPosition[0]][samsPosition[1]] = 'S';

                enemyCoordinates = GetEnemyCoordinates(samsPosition);

                if (room[enemyCoordinates[0]][enemyCoordinates[1]] == 'N' && samsPosition[0] == enemyCoordinates[0])
                {
                    room[enemyCoordinates[0]][enemyCoordinates[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintMatrix();
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static int[] GetEnemyCoordinates(int[] samsPosition)
        {
            int[] enemyCoordinates = new int[2];

            for (int j = 0; j < room[samsPosition[0]].Length; j++)
            {
                if (room[samsPosition[0]][j] != '.' && room[samsPosition[0]][j] != 'S')
                {
                    enemyCoordinates[0] = samsPosition[0];
                    enemyCoordinates[1] = j;
                }
            }

            return enemyCoordinates;
        }

        private static void EnemiesMovement()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (IsNextMoveOfBInMatrix(row, col))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (IsNextMoveOfDInMatrix(row, col))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static bool IsNextMoveOfDInMatrix(int row, int col)
        {
            return row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length;
        }

        private static bool IsNextMoveOfBInMatrix(int row, int col)
        {
            return row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length;
        }

        private static int[] FindSamParameters()
        {
            int[] samsPosition = new int[2];

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samsPosition[0] = row;
                        samsPosition[1] = col;
                    }
                }
            }

            return samsPosition;
        }

        private static void FillMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
