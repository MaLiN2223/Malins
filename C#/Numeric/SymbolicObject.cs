using System;
using System.Numerics;
using System.Runtime.CompilerServices;


namespace Numeric
{
    /// <summary>
    /// Based on ideas in https://github.com/dharmatech/Symbolism
    /// </summary>
    public abstract class SymbolicObject : INumber, IComparable, IFormattable, ISymbolicObject
    {
        #region constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(int n) => new Integer(n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(long n) => new Integer(n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(decimal n) => new Integer(n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(short n) => new Integer(n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(BigInteger n) => new Integer(n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(double d) => new Real(d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SymbolicObject(float d) => new Real(d);
        #endregion
        #region IntegerOperators  
        public static SymbolicObject operator +(SymbolicObject o, BigInteger a) => o + new Integer(a);
        public static SymbolicObject operator -(SymbolicObject o, BigInteger a) => o - new Integer(a);
        public static SymbolicObject operator *(SymbolicObject o, BigInteger a) => o * new Integer(a);
        public static SymbolicObject operator /(SymbolicObject o, BigInteger a) => o / new Integer(a);
        public static SymbolicObject operator ^(SymbolicObject o, BigInteger a) => o ^ new Integer(a);
        #endregion



        #region IntegerOperators  
        public static SymbolicObject operator +(SymbolicObject o, int a) => o + new Integer(a);
        public static SymbolicObject operator -(SymbolicObject o, int a) => o - new Integer(a);
        public static SymbolicObject operator *(SymbolicObject o, int a) => o * new Integer(a);
        public static SymbolicObject operator /(SymbolicObject o, int a) => o / new Integer(a);
        public static SymbolicObject operator ^(SymbolicObject o, int a) => o ^ new Integer(a);
        #endregion















        protected abstract SymbolicObject Sum(SymbolicObject nr);
        protected abstract SymbolicObject Multiply(SymbolicObject nr);
        protected abstract SymbolicObject Divide(SymbolicObject nr);
        protected abstract SymbolicObject Power(SymbolicObject nr);
        public static SymbolicObject operator +(SymbolicObject first, SymbolicObject second)
        {
            return first.Sum(second);
        }
        public static SymbolicObject operator -(SymbolicObject first, SymbolicObject second)
        {
            return first.Sum(second);
        }
        public static SymbolicObject operator *(SymbolicObject first, SymbolicObject second)
        {
            return first.Multiply(second);
        }
        public static SymbolicObject operator /(SymbolicObject first, SymbolicObject second)
        {
            return first.Divide(second);
        }
        public static SymbolicObject operator ^(SymbolicObject first, SymbolicObject second)
        {
            return first.Power(second);
        }
        public static bool operator ==(SymbolicObject first, SymbolicObject second)
        {
            return first?.CompareTo(second) == 0;
        }
        public static bool operator !=(SymbolicObject first, SymbolicObject second)
        {
            return !(first == second);
        }
        public abstract int CompareTo(object obj);
        public abstract TypeCode GetTypeCode();
        public abstract bool ToBoolean(IFormatProvider provider);
        public abstract char ToChar(IFormatProvider provider);
        public abstract sbyte ToSByte(IFormatProvider provider);
        public abstract byte ToByte(IFormatProvider provider);
        public abstract short ToInt16(IFormatProvider provider);
        public abstract ushort ToUInt16(IFormatProvider provider);
        public abstract int ToInt32(IFormatProvider provider);
        public abstract uint ToUInt32(IFormatProvider provider);
        public abstract long ToInt64(IFormatProvider provider);
        public abstract ulong ToUInt64(IFormatProvider provider);
        public abstract float ToSingle(IFormatProvider provider);
        public abstract double ToDouble(IFormatProvider provider);
        public abstract decimal ToDecimal(IFormatProvider provider);
        public abstract DateTime ToDateTime(IFormatProvider provider);
        public abstract string ToString(IFormatProvider provider);
        public abstract object ToType(Type conversionType, IFormatProvider provider);
        public abstract string ToString(string format, IFormatProvider formatProvider);
    }

    public interface ISymbolicObject
    {
    }

    public interface IExpression
    {
        SymbolicObject Evaluate();
    }
    public interface INumber : IConvertible
    {

    }
}
