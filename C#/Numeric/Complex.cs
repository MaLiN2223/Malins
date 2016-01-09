using System; 
using System.Globalization;

namespace Numeric
{
    public struct Complex : IEquatable<Complex>
    {
        public Complex(double real, double imaginary)
        {
            Re = real;
            Im = imaginary;
        }

        public readonly double Re;
        public readonly double Im;

        public bool Equals(Complex other)
        {
            return Math.Abs(Re - other.Re) <= 0 & Math.Abs(Im - other.Im) <= 0;
        }

        public override string ToString()
        {
            string sign = Im >= 0 ? "+" : "";
            return $"{Re.ToString(CultureInfo.InvariantCulture)}{sign}{Im.ToString(CultureInfo.InvariantCulture)}i";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Complex))
                return false;
            var another = (Complex)obj;
            return Equals(another);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }


        public static Complex operator +(Complex c, Complex c2)
        {
            return new Complex(c.Re + c2.Re, c.Im + c2.Im);
        }
        public static Complex operator -(Complex c, Complex c2)
        {
            return new Complex(c.Re - c2.Re, c.Im - c2.Im);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            double a = c1.Re;
            double b = c1.Im;
            double c = c2.Re;
            double d = c2.Im;
            return new Complex(a * c - b * d, b * c + a * d);
        }

        public static Complex operator *(Complex compl, int number)
        {
            return new Complex(compl.Re * number, compl.Im * number);
        }
        public static Complex operator *(Complex compl, double number)
        {
            return new Complex(compl.Re * number, compl.Im * number);
        }
        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Re, -c.Im);
        }
        public static Complex operator ^(Complex complex, int p)
        {
            if (p == 1)
                return complex;
            if (p % 2 == 0)
                return (complex * complex) ^ p / 2;
            return complex * ((complex * complex) ^ (p - 1) / 2);
        }
        public double Abs()
        {
            return Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
        }
    }
}
