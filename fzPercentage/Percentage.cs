using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fzPercentage
{
    public class Percentage : IEquatable<Percentage>
    {
        private readonly double value;

        public Percentage(double value)
        {
            this.value = value;
        }

        public static Percentage operator +(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value + p2.value);
        }

        public static Percentage operator -(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value - p2.value);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Percentage;
            if (other == null)
            {
                return false;
            }

            return value.Equals(other.value);
        }

        public static bool operator ==(Percentage p1, Percentage p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
            {
                return true;
            }
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }
            return p1.Equals(p2);
        }

        public static bool operator !=(Percentage p1, Percentage p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        bool IEquatable<Percentage>.Equals(Percentage other)
        {
            return value.Equals(other.value);
        }
    }
}
