using System;
using System.Collections.Generic;
using System.Text;

namespace Question03
{
    class Fraction
    {
        private readonly int numerator;
        private readonly int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static Fraction operator +(Fraction fr)
        {
            var result = new Fraction(fr.numerator, fr.denominator);

            return result.Simplified();
        }

        public static Fraction operator -(Fraction fr)
        {
            var result = new Fraction(-fr.numerator, fr.denominator);

            return result.Simplified();
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            var result = new Fraction(
                fr1.numerator * fr2.denominator + fr1.denominator * fr2.numerator,
                fr1.denominator * fr2.denominator);

            return result.Simplified();
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            var result = new Fraction(
                fr1.numerator * fr2.denominator - fr1.denominator * fr2.numerator,
                fr1.denominator * fr2.denominator);

            return result.Simplified();
        }

        public static Fraction operator !(Fraction fr)
        {
            var result = new Fraction(fr.denominator, fr.numerator);

            return result.Simplified();
        }

        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            var result = new Fraction(
                fr1.numerator * fr2.numerator,
                fr1.denominator * fr2.denominator);

            return result.Simplified();
        }

        public static Fraction operator /(Fraction fr1, Fraction fr2)
        {
            var result = new Fraction(
                fr1.numerator * fr2.denominator,
                fr1.denominator * fr2.numerator);

            return result.Simplified();
        }

        public override string ToString()
        {
            int n = numerator;
            int d = denominator;
            int div = GCD(Math.Abs(n), Math.Abs(d));

            if (n < 0 && d < 0)
            {
                n = Math.Abs(n);
                d = Math.Abs(d);
            }
            else if (n >= 0 && d < 0)
            {
                n *= -1;
                d = Math.Abs(d);
            }

            return n / div + " / " + d / div;
        }

        public static bool operator ==(Fraction fr1, Fraction fr2)
        {
            var simplifiedFr1 = fr1.Simplified();
            var simplifiedFr2 = fr2.Simplified();
            bool numeratorsAreEqual = simplifiedFr1.numerator == simplifiedFr2.numerator;
            bool denominatorsAreEqual = simplifiedFr1.denominator == simplifiedFr2.denominator;

            return numeratorsAreEqual && denominatorsAreEqual;
        }

        public static bool operator !=(Fraction fr1, Fraction fr2)
        {
            return !(fr1 == fr2);
        }

        public override bool Equals(object obj)
        {
            return Equals((Fraction)obj);
        }

        protected bool Equals(Fraction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return this == other;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (numerator * 397) ^ denominator;
            }
        }

        private Fraction Simplified()
        {
            int div = GCD(Math.Abs(numerator), Math.Abs(denominator));

            return new Fraction(numerator / div, denominator / div);
        }

        private int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
    }
}
