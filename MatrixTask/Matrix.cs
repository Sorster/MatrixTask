using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    class Matrix
    {
        static void Main(string[] args)
        {
            int rowSize = 0, coloumnSize = 0;
          
            InputMatrixSize(ref rowSize, ref coloumnSize);
            int[,] matrix = new int[rowSize, coloumnSize];

            InputMatrixElements(ref matrix, rowSize, coloumnSize);

            //Main menu 
            Menu(ref matrix, ref rowSize, ref coloumnSize);
        }

        //Set condition = 0 if users are not allowed to imput '0'
        static int InputAndCheck(int number, int condition = 1)
        {
            if (condition == 0)
            {
                do
                {
                    //check the right input
                    var check = (int.TryParse(Console.ReadLine(), out number));

                    if (number == 0)
                    {
                        Console.WriteLine("Error! This number can't be 0!");
                    }
                    else if (!check)
                    {
                        Console.WriteLine("\nError! Pleasa input a number!");
                    }
                    else break;

                } while (true);
            }
            if (condition == 1)
            {
                do
                {
                    //check the right input
                    var check = (int.TryParse(Console.ReadLine(), out number));

                    if (check)
                    {
                        break;
                    }
                    else if (!check)
                    {
                        Console.WriteLine("\nError! Pleasa input a number(integer)!");
                    }

                } while (true);
            }
          
            return number;
        }

        //The function input a matrix size
        static void InputMatrixSize(ref int rowSize, ref int coloumnSize)
        {
            Console.WriteLine("Input the size of rows: ");
            rowSize = InputAndCheck(rowSize, 0);

            Console.WriteLine("Input the size of coloumns: ");
            coloumnSize = InputAndCheck(coloumnSize, 0);
        }

        //This method full the matrix
        static void InputMatrixElements(ref int[,] matrix, int rowSize, int coloumnSize)
        {
            Console.WriteLine("1.Manual input \n2.Automatic input ");
            int condition = 0;

            condition = InputAndCheck(condition);

            if (condition == 1)
            {
                for (int i = 0; i < rowSize; i++)
                {
                    for (int j = 0; j < coloumnSize; j++)
                    {
                        Console.WriteLine($"X:{i + 1} Y:{j + 1} ");

                        matrix[i, j] = InputAndCheck(matrix[i, j], 1);
                    }
                }
            }

            else if (condition == 2)
            {
                Random rnd = new Random();

                for (int i = 0; i < rowSize; i++)
                {
                    for (int j = 0; j < coloumnSize; j++)
                    {
                        matrix[i, j] = rnd.Next(-10, 10);
                    }
                }
            }

            else
            {
                Console.WriteLine("Error! Please input 1 or 2!");
            }

            Console.Clear();
        }

        //The function output the matrix elements
        static void ShowMatrix(int[,] matrix, int rowSize, int coloumnSize)
        {
            Console.WriteLine("-----------Matrix-----------");

            for (int i = 0; i < rowSize; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < coloumnSize; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        //The function count a number of positive or negative numbers 
        static void NumberOfPositiveNegative(int[,] matrix, int rowSize, int coloumnSize)
        {
            int choice = 0;
            Console.WriteLine("1.Negative. \n2.Positive.");
            choice = InputAndCheck(choice, 0);
         
            switch (choice)
            {
                //counter of negative numbers
                case 1:
                    {
                        int count = 0;
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                if (matrix[i, j] < 0) count++;
                            }
                        }

                        Console.WriteLine($"Amount of the negative numbers: {count}");

                        break;
                    }
                //counter of positive numbers
                case 2:
                    {
                        int count = 0;
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                if (matrix[i, j] > 0) count++;
                            }
                        }

                        Console.WriteLine($"Amount of the positive numbers: {count}");

                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nPlease retry your inut!");

                        break;
                    }
            }
        }

        //The function sort the matrix to lower or to upper element
        static void SortArray(int[,] matrix, int rowSize, int coloumnSize)
        {        
            Console.Write("1.To lower\n2.To upper\nCommand :> ");
            int choice = 0;
            choice = InputAndCheck(choice, 0);

            switch (choice)
            {
                //sort to lower
                case 1:
                    {
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                for (int x = 1; x < coloumnSize; x++)
                                {
                                    if (matrix[i, x] > matrix[i, x - 1])
                                    {
                                        int temp = matrix[i, x];
                                        matrix[i, x] = matrix[i, x - 1];
                                        matrix[i, x - 1] = temp;
                                    }
                                }
                            }
                        }

                        break;
                    }

                //sort to upper
                case 2:
                    {
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                for (int x = 1; x < coloumnSize; x++)
                                {
                                    if (matrix[i, x] < matrix[i, x - 1])
                                    {
                                        int temp = matrix[i, x];
                                        matrix[i, x] = matrix[i, x - 1];
                                        matrix[i, x - 1] = temp;
                                    }
                                }
                            }
                        }

                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nPlease retry your inut!");
                        break;
                    }
            }
        }

        //The function reverse the matrix
        static void ReverseArray(ref int[,] matrix, int rowSize, int coloumnSize)
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < coloumnSize / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, coloumnSize - j - 1];
                    matrix[i, coloumnSize - j - 1] = temp;
                }
            }
        }

        //The function calculate a sum or a composition of matrix elements
        static void MathOperations(int[,] matrix, int rowSize, int coloumnSize)
        {
            Console.Write("\n1.The sum of the matrix elemnts\n2.The composition of the matrix elemnts\nOperation :> ");
            int choice = 0;
            choice = InputAndCheck(choice, 0);

            switch (choice)
            {
                //calculating the sum of the elements
                case 1:
                    {
                        int sum = 0;
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                sum += matrix[i, j];
                            }

                        }

                        Console.WriteLine($"The sum of the elements: {sum}");

                        break;
                    }

                //calculating the composition of the elements
                case 2:
                    {
                        int comp = 1;
                        for (int i = 0; i < rowSize; i++)
                        {
                            for (int j = 0; j < coloumnSize; j++)
                            {
                                comp *= matrix[i, j];
                            }

                        }

                        Console.WriteLine($"The composition of the elements: {comp}");

                        break;
                    }

                default:
                    {
                        Console.WriteLine("\nPlease retry your inut!");

                        break;
                    }
            }
        }

        static void Menu(ref int[,] matrix, ref int rowSize, ref int coloumnSize)
        {
            do
            {
                Console.Write("Menu: \n1.Input a matrix\n2.Sort the array\n3.Inversion of elemnts\n4.Mathematic operation\n5.A number of positive/negative numbers\n6.Show the matrix\n7.Close the program\nOperation :> ");

                int choice = 0;
                choice = InputAndCheck(choice, 0);

                Console.Clear();

                //the program end condition
                if (choice == 7) break;

                switch (choice)
                {
                    //Count a number of positive/negative numbers
                    case 1:
                        {
                            InputMatrixSize(ref rowSize, ref coloumnSize);
                            matrix = new int[rowSize, coloumnSize];
                            InputMatrixElements(ref matrix, rowSize, coloumnSize);

                            break;
                        }

                    //Sort the matrix
                    case 2:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);
                            SortArray(matrix, rowSize, coloumnSize);
                            ShowMatrix(matrix, rowSize, coloumnSize);

                            break;
                        }

                    //Reverse the matrix
                    case 3:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);
                            ReverseArray(ref matrix, rowSize, coloumnSize);
                            ShowMatrix(matrix, rowSize, coloumnSize);

                            break;
                        }

                    //Math operations of the matrix
                    case 4:
                        {
                            MathOperations(matrix, rowSize, coloumnSize);
               
                            break;
                        }

                    //Reinput the matrix elements
                    case 5:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);
                            NumberOfPositiveNegative(matrix, rowSize, coloumnSize);

                            break;
                        }

                    //Shiw the matrix
                    case 6:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nError! Please input a number from 1 to 5!");
                            break;
                        }
                }

                ContinueAndClear();

            } while (true);
        }

        //This method pause the program until the user input any key. Then the method clear the console
        static void ContinueAndClear()
        {
            Console.WriteLine("Press any key to continue the program...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}