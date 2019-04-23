using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erro
{
    class Meteorologist
    {
        public int[] rainfall = new int[12];
        public int[] pollution = new int[12];
        public Meteorologist()
        {
            int i = 0;
            for(i=0;i<12;i++)
            {
                rainfall[i] = i ;
                pollution[i] = rainfall[i] + 24;
            }
        }
        public int GetAveragePollution(int index)
        {
            try
            {
                return pollution[index] / rainfall[index];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: 下标越界! {0}", e);
                return -1;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Error: 除数不能为0！{0}", e);
                return -1;
            }
        }
        public int GetRainfall(int index)
        {
            try
            {
                return rainfall[index];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Error: 下标越界! {0}", e);
                return -1;
            }
           
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Meteorologist m = new Meteorologist();

            Console.WriteLine("GetRainfall测试:\n");
            Console.WriteLine("m.GetRainfall(3): {0}", m.GetRainfall(3));
            Console.WriteLine("m.GetRainfall(20): {0}", m.GetRainfall(20));

            Console.WriteLine("\n\n");

            Console.WriteLine("GetAveragePollution测试:\n");
            Console.WriteLine("GetAveragePollution(3): {0}", m.GetAveragePollution(3));
            Console.WriteLine("GetAveragePollution(0): {0}", m.GetAveragePollution(0));
            Console.ReadKey();
        }
    }
}
