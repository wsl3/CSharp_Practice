using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    class Employee
    {
        public string name;
        public string address;
        public string birthday;
        public int base_salary;
        public Employee(string n, string a, string b, int base_s)
        {
            name = n;
            address = a;
            birthday = b;
            base_salary = base_s;
        }
    }
    //程序员，秘书，高层管理，清洁工
    class Programmer:Employee
    {
        public Programmer(string n, string a, string b) : base(n, a, b, 10000) { }
        public int salary(int up)
        {
            return base_salary + up;
        }
    }
    class Manager : Employee
    {
        public Manager(string n, string a, string b) : base(n, a, b, 2000) { }
        public int salary(int up)
        {
            return base_salary + up;
        }
    }
    class secretary : Employee
    {
        public secretary(string n, string a, string b) : base(n, a, b, 3000) { }
        public int salary()
        {
            return base_salary;
        }
    }
    class Cleaner : Employee
    {
        public Cleaner(string n, string a, string b) : base(n, a, b, 1000) { }
        public int salary()
        {
            return base_salary;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
