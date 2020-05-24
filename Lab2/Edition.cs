using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Edition
    {
        protected string _name;
        protected DateTime _releaseDate;
        protected int _copiesCount;

        public Edition(string name, DateTime releaseDate, int copiesCount)
        {
            _name = name;
            _releaseDate = releaseDate;
            _copiesCount = copiesCount;
        }

        public Edition()
        {
            _name = default;
            _releaseDate = default;
            _copiesCount = default;
        }

        public string Name { get => _name; set => _name = value; }
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int CopiesCount
        {
            get => _copiesCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect copies count");
                }
                _copiesCount = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(_name, new DateTime(_releaseDate.Ticks), _copiesCount);
        }



        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _releaseDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _copiesCount;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(_name)}: {_name}, {nameof(_releaseDate)}: {_releaseDate}, {nameof(_copiesCount)}: {_copiesCount}";
        }

        public override bool Equals(object obj)
        {
            return obj is Edition edition &&
                    _name == edition._name &&
                    _releaseDate == edition._releaseDate &&
                    _copiesCount == edition._copiesCount;
        }

        public static bool operator ==(Edition left, Edition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            return !Equals(left, right);
        }
    }
}
