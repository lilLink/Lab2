using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Article : IRateAndCopy
    {
        public Person Author { get; set; }
        public String ArticleName { get; set; }
        private double ArticleRate { get; set; }

        public Article(Person author, String articleName, double articleRate)
        {
            Author = author;
            ArticleName = articleName;
            ArticleRate = articleRate;
        }
        public Article()
        {
            Author = new Person();
            ArticleName = default;
            ArticleRate = default;
        }

        public override string ToString()
        {
            return "Author {" + Author + "} ArticleName: " + ArticleName
                + ArticleRate;
        }

        public object DeepCopy()
        {
            return new Article(Author.DeepCopy(), string.Copy(ArticleName), ArticleRate);
        }

        public double Rating => ArticleRate;
    }
}
