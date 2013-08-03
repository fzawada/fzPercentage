using System;
using System.Globalization;
using System.Text.RegularExpressions;

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

        public static Percentage operator *(Percentage p1, double d)
        {
            return new Percentage(p1.value * d);
        }

        public static Percentage operator *(Percentage p1, decimal d)
        {
            return new Percentage(p1.value * (double)d);
        }

        public static Percentage operator *(Percentage p1, long d)
        {
            return new Percentage(p1.value * d);
        }

        public static Percentage operator *(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value * p2.value/100);
        }

        public static Percentage operator /(Percentage p1, double d)
        {
            return new Percentage(p1.value / d);
        }

        public static Percentage operator /(Percentage p1, decimal d)
        {
            return new Percentage(p1.value / (double)d);
        }

        public static Percentage operator /(Percentage p1, long d)
        {
            return new Percentage(p1.value / d);
        }

        public static Percentage operator /(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value / (p2.value / 100));
        }

        public static Percentage Parse(string value)
        {
            return Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static Percentage Parse(string value, IFormatProvider formatProvider)
        {
            return Parse(value, NumberStyles.Any, formatProvider);
        }

        public static Percentage Parse(string value, NumberStyles numberStyles)
        {
            return Parse(value, numberStyles, CultureInfo.InvariantCulture);
        }

        private const string Regex = @"(.*)(\% *)$";
        public static Percentage Parse(string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            var removedTrailingPecentSign = System.Text.RegularExpressions.Regex.Replace(value, Regex, "$1");
            if (removedTrailingPecentSign.Contains("%"))
            {
                throw new FormatException(value + " is not a correct Percentage");
            }
            var d = double.Parse(removedTrailingPecentSign, numberStyles, formatProvider);
            return new Percentage(d);
        }

        public static bool TryParse(string value, out Percentage result)
        {
            return TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        public static bool TryParse(string value, NumberStyles numberStyles, IFormatProvider formatProvider, out Percentage result)
        {
            var removedTrailingPecentSign = System.Text.RegularExpressions.Regex.Replace(value, Regex, "$1");
            if (removedTrailingPecentSign.Contains("%"))
            {
                result = null;
                return false;
            }
            double doubleResult;
            if (!double.TryParse(value, numberStyles, formatProvider, out doubleResult))
            {
                result = null;
                return false;
            }

            result = new Percentage(doubleResult);
            return true;
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

        public override string ToString()
        {
            return value + "%";
        }
    }
}
