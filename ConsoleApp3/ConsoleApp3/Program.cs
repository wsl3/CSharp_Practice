using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class1
    {
        static void Main(string[] args)
        {
            string name, number;
            double score;
            int i;
            Student[] student = new Student[3];
            for(i=0; i<3; i++)
            {
                Console.WriteLine("第{0}个学生", (i+1));
                Console.Write("name: ");
                name = Console.ReadLine();
                Console.Write("number: ");
                number = Console.ReadLine();
                Console.Write("score: ");
                score = Convert.ToDouble(Console.ReadLine());
                student[i] = new Student(name, number, score);
            }
            for(i=0; i<3; i++)
            {
                student[i].printInfo();
            }
            Student.printAll();
            Console.ReadKey();
        }
    }

    class Student
    {
        private string name;
        private string number;
        private double score;
        private static int people=0;
        private static double scoreAll=0;
        private static double avgScore=0;

        public Student(string n, string nu, double s)
        {
            name = n;
            number = nu;
            score = s;

            people += 1;
            scoreAll += score;
            avgScore = scoreAll / people;
        }

        public void printInfo()
        {
            Console.WriteLine("姓名:{0}, 学号:{1}, 成绩:{2}", name, number, score);

        }
        public static void printAll()
        {
            Console.WriteLine("学生人数:{0}, 总分:{1}, 平均分:{2}", people, scoreAll, avgScore);
        }
    }
}
