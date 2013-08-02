﻿using System;
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
