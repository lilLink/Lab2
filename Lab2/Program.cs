using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition edition1 = new Edition("NY Times", new DateTime(2000, 09, 02), 300);
            Edition edition2 = new Edition("NY Times", new DateTime(2000, 09, 02), 300);

            Console.WriteLine("Рівність посилань : " + Object.ReferenceEquals(edition1, edition2));
            Console.WriteLine("Рівність об'єктів: " + (edition1 == edition2));

            try
            {
                edition1.CopiesCount = -100;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Magazine magazine = new Magazine("Daily Bugles", Frequency.Monthly, new DateTime(2010, 12, 12), 250000);

            magazine.AddArticles(new Article(new Person("Nick", "Back", new DateTime(1990, 10, 20)),
                "Corona-Time", 2.2));
            magazine.AddEditors(new Person("Kek", "lol", new DateTime(1988, 8, 7)));

            Magazine magazineCopy = (Magazine)magazine.DeepCopy();
            magazineCopy.CopiesCount = 1;

            Console.WriteLine("Original: " + magazine);
            Console.WriteLine("Copy: " + magazineCopy);

            foreach (Article article in magazine.ArticlesMoreThan(2))
            {
                Console.WriteLine(article);
            }

            foreach (Article article in magazine.ArticlesWithName("Corona"))
            {
                Console.WriteLine(article);
            }

            Console.Read();
        }
    }
}
