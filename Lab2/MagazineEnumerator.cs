using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class MagazineEnumerator : IEnumerator
    {
        public ArrayList _articles;

        private int _position = -1;

        public MagazineEnumerator(ArrayList articles)
        {
            _articles = articles;
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _articles.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current => _articles[_position];


    }
}
