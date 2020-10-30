using System;


    class Program
    {
        static void Main()
        {
          
             Console.WriteLine("Enter x");  
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter y");  
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter z");  
            double z = double.Parse(Console.ReadLine());

            if ( y!=1 && z!=0)
            {
                double a = Math.Pow(x + y*y + 2*z, (1/3)) / (Math.Abs(1-y)*(z*z));
                Console.WriteLine("a = {0}",a);

                if (a==0)
                {
                   Console.WriteLine("При а=0 обчислити b неможливо");
                }
                else
                {
                double b = Math.Sin((x*x)/a + y*Math.Pow(z,3));
                Console.WriteLine("b = {0}",b);
                }
            }
            else
            Console.WriteLine("Значення не задовольняють ОДЗ");
        }
    }

