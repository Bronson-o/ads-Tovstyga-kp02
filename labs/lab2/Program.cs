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
          if ((N > 0) && (N == M)) 
            {
            Console.WriteLine("Введіть 1, щоб заповнити матрицю рандомно. Введіть 2, щоб заповнити матрицю числами від 0 дo N*M");
            n = int.Parse(Console.ReadLine());

                if (n==1)
                {
                    test = CreateRandomM(N, M);
                    PrintM(test);
                    Algo(N, M, test);
                }
                else
                if (n == 2)
                {
                    test = CreateM(N,M);
                    PrintM(test);
                    Algo(N, M, test);
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
                    matrix[i, j] = random.Next(0, N*M); 
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
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Algo(int N, int M, int[,] test)
        {
            int i = 0;
            int j = 0;
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            int count = 0;
            int counter = 0;
            int counter_ = 0;
            int counter2 = 0;
            int counter3 = 0;
            int min = 99;
            int max = 10;
            int num = 0;
            counter = N - 2;
            int[] B = new int[(N * N) / 2 - N/ 2];
            int[] C = new int[(N * N) / 2 + N/ 2];
            // first part(lower)           
            i = 1;
            j = 0;

            for (count = 0; count < N - 2; count++)
                {

                    if (test[i, j] > max)
                    {

                        max = test[i, j];
                        x1 = i;
                        y1 = j;
                    }
                    B[counter2] = test[i, j];
                    counter2++;
                    i++;
                }

            while (counter != 0)
                {

                    if (counter != 0)
                    {

                        for (count = 0; count < counter; count++)
                        {

                            if (test[i, j] > max)
                            {

                                max = test[i, j];
                                x1 = i;
                                y1 = j;
                            }
                            B[counter2] = test[i, j];
                            counter2++;
                            j++;
                        }

                        counter--;
                    }

                if (counter != 0)
                    {

                        for (count = 0; count < counter; count++)
                        {

                            if (test[i, j] > max)
                            {

                                max = test[i, j];
                                x1 = i;
                                y1 = j;
                            }
                            B[counter2] = test[i, j];
                            counter2++;
                            i--;
                            j--;
                        }

                        counter--;
                    }
                }
            if (test[i, j] > max)
                {

                    max = test[i, j];
                    x1 = i;
                    y1 = j;
                }
                B[counter2] = test[i, j];
                counter2++;
                Console.WriteLine("lower part: ");

            for (i = 0; i < (N * N / 2 - N / 2); i++)
                {

                    Console.Write("{0 } ",B[i]);
                }
                Console.WriteLine();
            // upper part
                i = 0;
                j = 0;
                counter = N - 1;

                while (i != counter)
                {

                    for (count = 0; count < N - 1; count++)
                    {

                        if (test[i, j] < min)
                        {

                            min = test[i, j];
                            x2 = i;
                            y2 = j;
                        }
                        C[counter3] = test[i, j];
                        counter3++;
                        i++;
                        j++;
                    }
                }

                while (counter != 0)
                {

                    if (counter != 0)
                    {

                        for (count = 0; count < counter; count++)
                        {

                            if (test[i, j] < min)
                            {

                                min = test[i, j];
                                x2 = i;
                                y2 = j;
                            }
                            C[counter3] = test[i, j];
                            counter3++;
                            i--;
                        }

                        counter--;
                    }

                    if (counter != 0)
                    {

                        for (count = 0; count < counter; count++)
                        {

                            if (test[i, j] < min)
                            {

                                min = test[i, j];
                                x2 = i;
                                y2 = j;
                            }
                            C[counter3] = test[i, j];
                            counter3++;
                            j--;
                        }

                        counter--;
                    }

                    if (counter != 0)
                    {

                        for (count = 0; count < counter; count++)
                        {

                            if (test[i, j] < min)
                            {

                                min = test[i, j];
                                x2 = i;
                                y2 = j;
                            }
                            C[counter3] = test[i, j];
                            counter3++;
                            i++;
                            j++;
                        }

                        counter--;
                    }
                }
                if (test[i, j] < min)
                {

                    min = test[i, j];
                    x2 = i;
                    y2 = j;
                }
                C[counter3] = test[i, j];
                counter3++;
                Console.WriteLine("upper part: ");

                for (i = 0; i < (N * N / 2 + N / 2); i++)
                {
                    Console.Write(" {0}",C[i]);
                }
            Console.WriteLine("\nMax of lower part = {0}, koord = {1}, {2}", max, x1, y1);
            Console.WriteLine("Min of upper part = {0}, koord = {1}, {2}", min, x2, y2);
        } 
}
   