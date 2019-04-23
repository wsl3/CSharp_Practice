using System;
using System.Data;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Circle
    {
        public double radius;
        public Circle(double r)
        {
            radius = r;
        }

    }
    class Ball:Circle
    {
        public Ball(double r):base(r) {}
        public double size()
        {

            return (4/3)* Math.PI * Math.Pow(radius, 3);
        }
    }
    class Columns : Circle
    {
        public double hight;
        public Columns(double r, double h):base(r) { hight=h; }
        public double size()
        {

            return  Math.PI * Math.Pow(radius, 2)*hight;
        }
    }
    class Cones : Circle
    {
        public double hight;
        public Cones(double r, double h):base(r){ hight=h; }
        public double size()
        {

            return (1/3) * Math.PI* Math.Pow(radius, 2)*hight;
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Ball b = new Ball(2);
            Columns c = new Columns(2, 5);
            Cones con = new Cones(2, 5);

            Console.WriteLine("球: r={0}  size={1:F2}", b.radius, b.size());
            Console.WriteLine("圆柱: r={0} h={1} size={2:F2}", c.radius,c.hight, c.size());
            Console.WriteLine("圆锥: r={0} h={1} size={2:F2}", con.radius,con.hight, b.size());

            Console.Read();
        }
    }
}
