using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Magazine : Edition, IRateAndCopy, IEnumerable
    {

        private Frequency _frequency;
        private ArrayList _articles;
        private ArrayList _editors;

        public Magazine(string magazineName, Frequency frequency, DateTime releaseDate, int copiesCount)
        {
            _name = magazineName;
            _frequency = frequency;
            _releaseDate = releaseDate;
            _copiesCount = copiesCount;
            _articles = new ArrayList();
            _editors = new ArrayList();
        }

        public Magazine()
        {
            _name = default;
            _frequency = default;
            _releaseDate = default;
            _copiesCount = default;
            _articles = default;
            _editors = default;
        }

        public Frequency Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }



        public double Rating => (from Article article in _articles select article.Rating).Average();

        public bool this[Frequency frequency] => frequency == this._frequency;

        public ArrayList Articles
        {
            get => _articles;
            set => _articles = value;
        }

        public ArrayList Editors
        {
            get => _editors;
            set => _editors = value;
        }

        public Edition Edition
        {
            get => this;
            set
            {
                _name = value.Name;
                _releaseDate = value.ReleaseDate;
                _copiesCount = value.CopiesCount;
            }
        }

        public IEnumerable ArticlesMoreThan(double rate)
        {
            return (from Article article in _articles select article)
                .Where(article => article != null && article.Rating > rate);
        }

        public IEnumerable ArticlesWithName(string name)
        {
            return (from Article article in _articles select article)
                .Where(article => article.ArticleName.Contains(name));
        }

        public void AddArticles(params Article[] articles)
        {
            foreach (Article article in articles)
            {
                _articles.Add(article);
            }
        }

        public void AddEditors(params Person[] editors)
        {
            foreach (Person editor in editors)
            {
                _editors.Add(editor);
            }
        }

        public override string ToString()
        {
            return "MagazineName: " + _name + "; Frequency: " + _frequency.ToString() + "; ReleaseDate: " +
                _releaseDate.ToShortDateString() + "; CopiesCount: " + _copiesCount.ToString() + "; Articles: { " +
                string.Join(", ", (from Article article in _articles select article.ToString()).ToArray()) + " };";
        }

        public virtual string ToShortString()
        {
            return "MagazineName: " + _name + "; Frequency: " + _frequency.ToString() + "; ReleaseDate: " +
                _releaseDate.ToShortDateString() + "; CopiesCount: " + _copiesCount.ToString() + "; AvgRate: " + Rating;
        }


        public override object DeepCopy()
        {
            Magazine magazine = new Magazine(string.Copy(_name), _frequency, new DateTime(_releaseDate.Year,
                _releaseDate.Month, _releaseDate.Day), _copiesCount)
            {
                Articles = new ArrayList((from Article article in _articles select article.DeepCopy()).ToArray()),
                Editors = new ArrayList((from Person person in _editors select person.DeepCopy()).ToArray())
            };
            return magazine;
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(_articles);
        }

        public IEnumerator AuthorsWhichAreEditors()
        {
            IEnumerator enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (_editors.Contains(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }

        public IEnumerator AuthorsWhoAreNotEditors()
        {
            IEnumerator enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!_editors.Contains(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}
