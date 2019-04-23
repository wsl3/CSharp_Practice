using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Card
    {
        public string title;
        public string author;
        public int amount;
        public void store(string t, string a, int am)
        {
            title = t;
            author = a;
            amount = am;
        }
        public void show()
        {
            Console.WriteLine("title:{0} author:{1} amount:{2}", title, author, amount);
        }
        static void sort(Card[] cards, int flag)
        {
            int i, j;
            Card temp;
            for (i=0;i<cards.Length-2;i++)
            {
                for(j=i+1;j<cards.Length-1;j++)
                {
                    if((flag == 1 && (String.Compare(cards[i].title,cards[j].title)==1))|| (flag == 3 && (cards[i].amount > cards[j].amount) || (flag == 2 && (String.Compare(cards[i].author, cards[j].author) == 1))))
                    {
                        temp = cards[i];
                        cards[i] = cards[j];
                        cards[j] = temp;
                    }              
                }
            }
        }
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int i, amount;
            string title, author;
            Card[] cards = new Card[num];
            for(i=0;i<num;i++)
            {
                title = Console.ReadLine();
                author = Console.ReadLine();
                amount = Convert.ToInt32(Console.ReadLine());

                cards[i] = new Card();
                cards[i].store(title, author, amount);
            }
            Console.WriteLine("库存信息:");
            for(i=0;i<num;i++)
            {
                cards[i].show();
            }
            Console.WriteLine("按title排列:");
            Card.sort(cards, 1);
            for (i = 0; i < num; i++)
            {
                cards[i].show();
            }
            Console.WriteLine("按amount排列:");
            Card.sort(cards, 1);
            for (i = 0; i < num; i++)
            {
                cards[i].show();
            }
            Console.ReadLine();
        }
    }
}
