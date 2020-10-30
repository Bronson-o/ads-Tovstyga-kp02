using System;

namespace Завдання_2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter d");
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter m");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter y");
            int y = int.Parse(Console.ReadLine());

            if (d < 32 && d > 0)
            {
                if ((m == 4 && d == 31) || (m == 6 && d == 31) || (m == 9 && d == 31) || (m == 11 && d == 31) || (m == 2 && d > 29))
                {
                    Console.WriteLine("Такої дати не існує");
                }
                else
                {
                    if (y > 0)
                    {
                        //проміжні змінні
                        int a = (14 - m) / 12;
                        int b = y + 4800 - a;
                        int c = m + 12 * a - 3;
                        int jdn = d + ((153 * c + 2) / 5) + (365 * b) + (b / 4) - 32083;
                        //ще трохи проміжних змінних
                        a = jdn + 32044;
                        b = (4 * a + 3) / 146097;
                        c = a - ((146097 * b) / 4);
                        int p = (4 * c + 3) / 1461;
                        int e = c - ((1461 * p) / 4);
                        int g = (5 * e + 2) / 153;
                        // обчислення шуканої дати
                        d = e - (153 * g + 2) / 5 + 1;
                        m = g + 3 - 12 * (g / 10);
                        y = 100 * b + p - 4800 + (g / 10);

                        Console.WriteLine("Дата по григоріанському календарю {0}.{1}.{2}", d, m, y);
                        Console.WriteLine("Сума днів з початку року = {0}", SumDays(d, m, y));
                    }
                    else
                        Console.WriteLine("Помилка вводу данних");
                }
            }
            else
                Console.WriteLine("Помилка вводу данних");

            //Сума днів
            static int SumDays(int d, int m, int y)
            {
                if ((m == 4 && d == 31) || (m == 6 && d == 31) || (m == 9 && d == 31) || (m == 11 && d == 31) || (m == 2 && d > 29))
                {
                    return 0;
                }
                else
                {
                    int Sum = 0;
                    int[] months = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

                    if (y % 4 == 0 && (y % 100 == 0 || y % 400 == 0))
                    {
                        months[2] = 29;
                    }
                    for (int i = 0; i < (m - 1); i = i + 1)
                    {
                        Sum = Sum + months[1];
                    }
                    Sum = Sum + d;
                    return Sum;
                }
            }







        }
    }
}
