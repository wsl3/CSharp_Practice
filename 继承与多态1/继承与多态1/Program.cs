using System;

namespace Program
{

    class Book
    {
        private readonly string isbn;
        private string title;
        private string author;
        private string press;
        private double price;

        public Book(string i, string t, string a, string p, double pr)
        {
            isbn = i;
            title = t;
            author = a;
            press = p;
            price = pr;
        }
        public Book(string i): this(i, "未知", "未知", "未知", 0){}
        
        public void show()
        {
            Console.WriteLine("isbn: {0}", isbn);
            Console.WriteLine("title: {0}", title);
            Console.WriteLine("author: {0}", author);
            Console.WriteLine("press: {0}", press);
            Console.WriteLine("price: {0}", price);
        }
        static void Main(string[] args)
        {
            Book b1 = new Book("ISBN123", "杀死一只知更鸟", "wws", "机械工业", 50.5);
            Book b2 = new Book("ISBN234");

            Console.WriteLine("book1");
            b1.show();
            Console.WriteLine("book2");
            b2.show();
            Console.Read();
        }
    }

  
}
