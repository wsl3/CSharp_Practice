using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    class Test
    {
        public delegate double Calculation(int a, int b);

        public static double avarge(int a, int b)
        {
            return Convert.ToDouble((a + b) / 2.0);
        }
        public static double sum(int a, int b)
        {
            return (a + b);
        }
        
        static void Main(string[] args)
        {
            Calculation c1 = new Calculation(avarge);
            Calculation c2 = new Calculation(sum);

            Console.WriteLine("委托1:求平均值");
            Console.WriteLine("Calculation(10,5):{0:F3}", c1(10,5));

            Console.WriteLine("委托2:求和");
            Console.WriteLine("Calculation(4,5):{0}", c2(4, 5));

            Console.ReadLine();
        }
    }
}
