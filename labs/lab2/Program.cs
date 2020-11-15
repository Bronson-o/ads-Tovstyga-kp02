using System;

class Program 
{
        static void Main(string[] args)
        {
          Console.WriteLine("Enter N");
          int N = int.Parse(Console.ReadLine());  
          Console.WriteLine("Enter M");
          int M = int.Parse(Console.ReadLine());  
          int[,] test;
          int n;
          if ((N > 1) && (N == M)) 
            {
            Console.WriteLine("Введіть 1, щоб заповнити матрицю рандомно. Введіть 2, щоб заповнити матрицю числами від 0 дo N*M");
            n = int.Parse(Console.ReadLine());

                if (n==1)
                {
                    test = CreateRandomM(N, M);
                    PrintM(test);
                    Lower(test, N);
                    Upper(test, N);
                }
                else
                if (n == 2)
                {
                    test = CreateM(N,M);
                    PrintM(test);
                    Lower(test, N);
                    Upper(test, N);
                }
                else
                 Console.WriteLine("Помилка вводу n");
            }
            else
             Console.WriteLine("Помилка вводу розміру матриці");

        }
        static int[,] CreateM(int N, int M)
        {
            int[,] m = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    m[i, j] = M * i + j;
                }
            }
            return m;
        }
        static int[,] CreateRandomM(int N, int M)
        {
            Random random = new Random();
            int[,] matrix = new int[N, M];
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    matrix[i, j] = random.Next(10, 100); 
                }
            }
            return matrix;
        }
        static void PrintM(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                    if(matrix[i,j] / 10 < 1)
                    {
                        Console.Write("  ");
                    }
                    else if(matrix[i,j] / 100 < 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Lower(int [,] matrix, int N)
        {
            int min_i = N-1;
            int min_j = N-2;
            Console.WriteLine("\nLower part:");
            for (int i = N-1; i>=1; i--)
            {
                for (int k = N - 2 - 2*(N-1-i); k >= (N-1-i); k--)
                {
                    Console.Write(matrix[i,k]+" ");
                    if (matrix[min_i, min_j] > matrix[i, k])
                    {
                        min_i = i;
                        min_j = k;
                    }
                }
                for (int k = N-2 - (N - 1 - i); k > 2*(N - 1 - i); k--)
                {
                    Console.Write(matrix[k, N-1-i]+" ");
                    if (matrix[min_i, min_j] > matrix[k, N-1-i])
                    {
                        min_i = k;
                        min_j = N-1-i;
                    }
                }
                for (int k = 2*(N-i); k < i; k++)
                {
                    Console.Write(matrix[k, k-(N-i)]+" ");
                    if (matrix[min_i, min_j] > matrix[k, k-(N-i)])
                    {
                        min_i = k;
                        min_j = k-(N-i);
                    }
                }              
            }
            Console.WriteLine("\nМiнiмум нижньої частини = {0} ({1},{2})", matrix[min_i, min_j], min_i + 1, min_j + 1);
        }
        static void Upper(int [,] matrix, int N)
        {
            int max_i = N-1;
            int max_j = N-1;
            Console.WriteLine("Upper part:");
            for (int i = N; i>=1; i--)
            {
                for (int k = N - 1 - 2*(N-i); k >= (N-i); k--)
                {
                    Console.Write(matrix[k, k+(N-i)]+" ");
                    if (matrix[max_i, max_j] < matrix[k, k+(N-i)])
                    {
                        max_i = k;
                        max_j = k+(N-i);
                    }
                }
                for (int k = 2*(N - i)+1; k <= i-1; k++)
                {
                    Console.Write(matrix[N-i, k]+" ");
                    if (matrix[max_i, max_j] < matrix[N-i, k])
                    {
                        max_i = N-i;
                        max_j = k;
                    }
                }
                for (int k = N-i+1; k <= N - 2*(N-i+1); k++)
                {
                    Console.Write(matrix[k, i-1]+" ");
                    if (matrix[max_i, max_j] < matrix[k, i-1])
                    {
                        max_i = k;
                        max_j = i-1;
                    }
                }              
            }
            Console.WriteLine("\nМаксимум верхньої частини = {0} ({1},{2})", matrix[max_i, max_j], max_i + 1, max_j + 1);
        }
}
   