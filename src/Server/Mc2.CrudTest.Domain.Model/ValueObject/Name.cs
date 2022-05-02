using Mc2.CrudTest.Domain.Model.Exceptions;
using System;

namespace Mc2.CrudTest.Domain.Model.ValueObject
{
    public class Name
    {
        Name() { }
        private Name(string first, string last)
        {
            Validate(first, last);

            First = first;
            Last = last;
        }

        public string First { get; private set; }
        public string Last { get; private set; }


        public static Name Create(string first, string last)
        => new Name(first, last);

        public override bool Equals(object obj)
            => obj is Name other ? other.First.Equals(First) && other.Last.Equals(Last) : false;

        public override int GetHashCode()
            => First.GetHashCode() ^ Last.GetHashCode();



        private void Validate(string first, string last)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(last))
            {
                throw new CustomerNameIsNullOrEmptyException();
            }
        }
    }
}
