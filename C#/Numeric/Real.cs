
using System;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Numeric
{
    public sealed class Real : SymbolicObject,
        IEquatable<Real>, IComparable<Real>,
        IEquatable<double>, IComparable<double>,
        IEquatable<float>, IComparable<float>
    {
        #region Casting 
        #region implicit
        public static implicit operator Real(int k) => new Real(k);

        public static implicit operator Real(long k) => new Real(k);
        #endregion
        #region explicit  
        public static explicit operator double(Real k) => double.Parse(k.IntegerPart + "." + k.FractionalPart, CultureInfo.InvariantCulture);
        public static explicit operator float(Real k) => float.Parse(k.IntegerPart + "." + k.FractionalPart, CultureInfo.InvariantCulture);
        #endregion
        #endregion

        public BigInteger IntegerPart { get; private set; }
        public BigInteger FractionalPart { get; private set; }
        private const string IntStr = @"(\d*?)\.";
        private const string FracString = @"\.(\d*)";
        private static readonly Regex IntRegex = new Regex(IntStr);
        private static readonly Regex FractionRegex = new Regex(FracString);
        private const double Threshold = 0.000000000001;
        public Real(double d) : this(d.ToString(CultureInfo.InvariantCulture))
        {
        }

        public Real(float d) : this(d.ToString(CultureInfo.InvariantCulture))
        {
        }
        private Real()
        {

        }
        public Real(string d)
        {
            var matchInt = IntRegex.Match(d);
            if (matchInt.Groups.Count != 2)
                throw new ArgumentException();
            var matchFrac = FractionRegex.Match(d);
            if (matchFrac.Groups.Count != 2)
                throw new ArgumentException();
            IntegerPart = BigInteger.Parse(matchInt.Groups[1].Captures[0].Value);
            FractionalPart = BigInteger.Parse(matchFrac.Groups[1].Captures[0].Value, CultureInfo.InvariantCulture);
            //TODO : 1.0000001 stworzy 1.1 - to nie dobrze
        }

        public SymbolicObject Simplify(double threshold = Threshold)
        {
            throw new NotImplementedException();
        }

        protected override SymbolicObject Sum(SymbolicObject nr)
        {
            if (nr == null)
                throw new ArgumentNullException(nameof(nr));
            var output = new Real();
            var integer = nr as Integer;
            if (integer != null)
            {
                output.FractionalPart = FractionalPart;
                var k = (BigInteger)integer;
                output.IntegerPart = IntegerPart + k;
                return output;
            }
            if (nr is Real)
            {

            }
            if (nr is Rational)
            {

            }
            throw new NotSupportedException();
        }

        protected override SymbolicObject Multiply(SymbolicObject nr)
        {
            throw new NotImplementedException();
        }

        protected override SymbolicObject Divide(SymbolicObject nr)
        {
            throw new NotImplementedException();
        }

        protected override SymbolicObject Power(SymbolicObject nr)
        {
            throw new NotImplementedException();
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public override bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Real other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Real other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(double other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(double other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(float other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(float other)
        {
            throw new NotImplementedException();
        }
    }
}
