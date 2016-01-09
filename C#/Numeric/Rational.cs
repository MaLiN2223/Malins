
using System;

namespace Numeric
{
    public class Rational : SymbolicObject
    {
        private Integer _up;
        private Integer _down;

        public Rational(Integer up, Integer down)
        {
            _up = up;
            if (down == 0)
                throw new System.ArgumentException("Denominator must be non-zero.");
            _down = down;

        }


        protected override SymbolicObject Sum(SymbolicObject nr)
        {
            throw new NotImplementedException();
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
    }
}
