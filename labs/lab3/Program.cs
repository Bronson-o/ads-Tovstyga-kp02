using System;
using System.Collections.Generic;
using System.Linq;
namespace SortApp
{
    class Program
    {
        static int[] CreateUniqueRandomMatrix(int N)
        {
            int[] matrix = new int[N];
            Random r = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                var next = 0;                
                while (true)
                {
                    next = r.Next(0, 100);
                    if (!Contains(matrix, next))
                    { 
                        break;
                    }                    
                }
                matrix[i] = next;
            }
            return matrix;
        }
        static bool Contains(int[] matrix, int value)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] == value) 
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Enter N");
            bool Ncheck = int.TryParse(Console.ReadLine(), out N);
            int [] matrix = new int [N];
            matrix = CreateUniqueRandomMatrix(N);
            PrintMatrix(matrix);
            List<int> ListSmaller = new List<int>();
            ListSmaller = SortSmallerNumbers(ListSmaller, matrix);
            List<int> ListBigger = new List<int>();
            ListBigger = SortBiggerNumbers(ListBigger, matrix);
            List<int> List0 = new List<int>();
            List0.Add(matrix[0]);
            List<int> ListTemp = ListBigger.Union(List0).ToList();
            List<int> List = ListTemp.Union(ListSmaller).ToList();

            List<int> ListMatrix = new List<int>();
            for (int j = 0; j < matrix.Length; j++)
            {
                ListMatrix.Add(matrix[j]);
            }
            Console.Write("\n");
            PrintList(ListMatrix, List);
        }
        static void PrintMatrix(int[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("{0} ", matrix[i]);
            }
            Console.WriteLine();
        }  
        static List<int> SortSmallerNumbers(List<int> List, int[] matrix)
        {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j] < matrix[0])
                    {
                        List.Add(matrix[j]);
                    }
                }
                for (int i = 0; i < List.Count; i++)
                {
                    for (int j = i + 1; j < List.Count; j++)
                    {
                        if (List[i] > List[j])
                        {
                            int temp = List[i];
                            List[i] = List[j];
                            List[j] = temp;
                        }                   
                    }            
                }
            return List;
        }
        static List<int> SortBiggerNumbers(List<int> List, int[] matrix)
        {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j] > matrix[0])
                    {
                        List.Add(matrix[j]);
                    }
                }
                for (int i = 0; i < List.Count; i++)
                {
                    for (int j = i + 1; j < List.Count; j++)
                    {
                        if (List[i] < List[j])
                        {
                            int temp = List[i];
                            List[i] = List[j];
                            List[j] = temp;
                        }                   
                    }            
                }
            return List;
        }
        static void PrintList(List<int> ListMatrix, List<int> List)
        {
            Console.WriteLine("Initial array:");
            for (int i = 0; i < List.Count; i++)
            {
                if (ListMatrix[i]==List[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int val1 = ListMatrix[i];
                    Console.Write("{0} ", val1);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    int val1 = ListMatrix[i];
                    Console.Write("{0} ", val1);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i]==ListMatrix[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int val1 = List[i];
                    Console.Write("{0} ", val1);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    int val1 = List[i];
                    Console.Write("{0} ", val1);
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\nGreen color - not sorted");
            Console.WriteLine("Red color - sorted");
        }
    }
}


