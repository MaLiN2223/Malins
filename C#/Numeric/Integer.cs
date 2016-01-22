namespace Numeric
{
    using System;
    using System.Numerics;

    public class Integer : SymbolicObject,
        IEquatable<Integer>, IComparable<Integer>,
        IEquatable<int>, IComparable<int>,
        IEquatable<long>, IComparable<long>,
        IEquatable<short>, IComparable<short>,
        IEquatable<decimal>, IComparable<decimal>
    {
        private BigInteger _data;

        public Integer(BigInteger i)
        {
            _data = i;
        }

        public Integer(int i)
        {
            _data = new BigInteger(i);
        }

        public Integer(long i)
        {
            _data = new BigInteger(i);
        }

        public Integer(decimal i)
        {
            _data = new BigInteger(i);
        }

        public Integer(short i)
        {
            _data = new BigInteger(i);
        }

        protected override SymbolicObject Sum(SymbolicObject obj)
        {
            //TODO : Sumowanie
            var k = obj as Integer;
            if (k != null)
                return new Integer(_data + k._data);
            var k2 = obj as Real;
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


        public override TypeCode GetTypeCode()
        {
            //TODO : GetTypeCode()
            throw new NotImplementedException();
        }
        #region Conversions
        public override string ToString(string format, IFormatProvider formatProvider)
        {
            return _data.ToString(formatProvider);
        }

        public override bool ToBoolean(IFormatProvider provider)
        {
            return bool.Parse(_data.ToString(provider));
        }

        public override char ToChar(IFormatProvider provider)
        {
            return char.Parse(_data.ToString(provider));
        }

        public override sbyte ToSByte(IFormatProvider provider)
        {
            return sbyte.Parse(_data.ToString(provider));
        }

        public override byte ToByte(IFormatProvider provider)
        {
            return byte.Parse(_data.ToString(provider));
        }

        public override short ToInt16(IFormatProvider provider)
        {
            return short.Parse(_data.ToString(provider));
        }

        public override ushort ToUInt16(IFormatProvider provider)
        {
            return ushort.Parse(_data.ToString(provider));
        }

        public override int ToInt32(IFormatProvider provider)
        {
            return int.Parse(_data.ToString(provider));
        }

        public override uint ToUInt32(IFormatProvider provider)
        {
            return uint.Parse(_data.ToString(provider));
        }

        public override long ToInt64(IFormatProvider provider)
        {
            return long.Parse(_data.ToString(provider));
        }

        public override ulong ToUInt64(IFormatProvider provider)
        {
            return ulong.Parse(_data.ToString(provider));
        }

        public override float ToSingle(IFormatProvider provider)
        {
            return float.Parse(_data.ToString(provider));
        }

        public override double ToDouble(IFormatProvider provider)
        {
            return double.Parse(_data.ToString(provider));
        }

        public override decimal ToDecimal(IFormatProvider provider)
        {
            return decimal.Parse(_data.ToString(provider));
        }

        public override DateTime ToDateTime(IFormatProvider provider)
        {
            return DateTime.Parse(_data.ToString(provider));
        }

        public override string ToString(IFormatProvider provider)
        {
            return _data.ToString(provider);
        }

        public override object ToType(Type conversionType, IFormatProvider provider)
        {
            //TODO : ToType
            throw new NotImplementedException();
        }
        #endregion

        #region comparators

        public int CompareTo(decimal other) => _data.CompareTo(other);

        public int CompareTo(int other) => _data.CompareTo(other);

        public int CompareTo(Integer other) => _data.CompareTo(other);

        public int CompareTo(long other) => _data.CompareTo(other);

        public int CompareTo(short other) => _data.CompareTo(other);

        public override int CompareTo(object obj)
        {
            if (!(obj is Integer))
                throw new ArgumentException("Wrong argument type", nameof(obj));
            return CompareTo((Integer)obj);
        }

        #endregion

        #region equality

        public bool Equals(decimal other)
        {
            throw new NotSupportedException();
        }

        public bool Equals(int other)
        {
            return Equals((Integer)other);
        }

        public bool Equals(Integer other) => other._data.Equals(_data);

        public bool Equals(long other) => _data.Equals(other);

        public bool Equals(short other) => _data.Equals(other);

        #endregion

        #region operators

        public static Integer operator %(Integer first, Integer second)
        {
            return new Integer(first._data % second._data);
        }

        public static Integer operator ++(Integer first)
        {
            return first._data++;
        } 

        public static bool operator <(Integer first, int second)
        {
            return first._data < second;
        }

        public static bool operator >(Integer first, int second)
        {
            return first._data > second;
        }

        public static Integer operator -(Integer data)
        {
            return new Integer(data._data);
        }

        #endregion

        #region Casting

        public static implicit operator Integer(int k) => new Integer(k);

        public static implicit operator Integer(long k) => new Integer(k);

        public static implicit operator Integer(short k) => new Integer(k);

        public static implicit operator Integer(decimal k) => new Integer(k);

        public static implicit operator Integer(BigInteger k) => new Integer(k);

        public static explicit operator BigInteger(Integer k) => k._data;

        #endregion
    }
}