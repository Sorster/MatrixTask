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
        //The function input a matrix size
        static void InputMatrixSize(ref int rowSize, ref int coloumnSize)
        {
            Console.WriteLine("Input the size of rows: ");

            do
            {
                //check the right input
                var check = (int.TryParse(Console.ReadLine(), out rowSize));

                if (rowSize == 0) 
                { 
                    Console.WriteLine("Error! Row size can't be 0!"); 
                }
                else if (!check) 
                { 
                    Console.WriteLine("\nError! Pleasa input a number!"); 
                }
                else break;


            } while (true);

            Console.WriteLine("Input the size of coloumns: ");

            do
            {
                //check the right input
                var check = (int.TryParse(Console.ReadLine(), out coloumnSize));

                if (coloumnSize == 0)
                {
                    Console.WriteLine("Error! Coloumn size can't be 0!");
                }
                else if (!check)
                {
                    Console.WriteLine("\nError! Pleasa input a number!");
                }
                else break;


            } while (true);
        }

        //The function input the matrix elemnts
        static void InputMatrixElements(ref int[,] matrix, int rowSize, int coloumnSize)
        {
            //Random rnd = new Random();
            for (int i = 0; i < rowSize; i++)
            {             
                for (int j = 0; j < coloumnSize; j++)
                {
                    int temp;

                    //temp = rnd.Next(-10,10);

                    Console.WriteLine($"X:{i + 1} Y:{j + 1} ");

                    do
                    {
                        //check the right input
                        var check = (int.TryParse(Console.ReadLine(), out temp));
                        
                        if (!check)
                        {
                            Console.WriteLine("\nError! Pleasa input a number!");
                        }
                        else break;

                    } while (true);

                    matrix[i, j] = temp;
                }
            }
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
            int choice1;

            Console.WriteLine("1.Negative. \n2.Positive.");
            
            do
            {
                //check the right input
                var check = (int.TryParse(Console.ReadLine(), out choice1));
                
                if (!check)
                {
                    Console.WriteLine("\nError! Please input a number!\nOperation :> ");
                }
                else break;

            } while (true);

            switch (choice1)
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
            int choice1;
            
            do
            {
                //check the right input
                var check = (int.TryParse(Console.ReadLine(), out choice1));
                if (!check) Console.WriteLine("\nError! Please input a number!\nOperation :> ");
                else break;

            } while (true);

            switch (choice1)
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
            int choice1;
            
            do
            {
                //check the right input
                var check = (int.TryParse(Console.ReadLine(), out choice1));
                if (!check) Console.Write("\nError! Pleasa input a number!\nOperation :> ");
                else break;

            } while (true);

            switch (choice1)
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
                Console.Clear();

                Console.Write("Menu: \n1.A number of positive/negative numbers\n2.Sort the array\n3.Inversion of elemnts\n4.Mathematic operation\n5.Reinput the matrix\n6.Show the matrix\n7.Close the program\nOperation :> ");

                int choice1;
                do
                {
                    //check the right input
                    var check = (int.TryParse(Console.ReadLine(), out choice1));
                   
                    if (!check)
                    {
                        Console.WriteLine("\nError! Pleasa input a number!");
                    }
                    else break;

                } while (true);

                //the condition of closing a program
                if (choice1 == 7) break;

                Console.Clear();

                switch (choice1)
                {
                    //Count a number of positive/negative numbers
                    case 1:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);
                            NumberOfPositiveNegative(matrix, rowSize, coloumnSize);

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
                            InputMatrixSize(ref rowSize, ref coloumnSize);
                            InputMatrixElements(ref matrix, rowSize, coloumnSize);
                            ShowMatrix(matrix, rowSize, coloumnSize);

                            break;
                        }
                    //Shiw the matrix
                    case 6:
                        {
                            ShowMatrix(matrix, rowSize, coloumnSize);

                            break;
                        }
                    //Close the program
                    case 7:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nError! Please input a number from 1 to 5!");
                            break;
                        }
                }

                Console.WriteLine("Press any ey to continue the program...");
                Console.ReadKey();

            } while (true);
        }

        static void Main(string[] args)
        {
            //variables of coloumns and rows size
            int rowSize = 0, coloumnSize = 0;

            //Input the matrix size
            InputMatrixSize(ref rowSize, ref coloumnSize);

            int[,] matrix = new int[rowSize, coloumnSize];

            //Input the matrix elements
            InputMatrixElements(ref matrix, rowSize, coloumnSize);

            //The first matrix show
            ShowMatrix(matrix,rowSize,coloumnSize);

            //Choice the operation 
            Menu(ref matrix, ref rowSize, ref coloumnSize);
        }
    }
}