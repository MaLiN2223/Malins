namespace DataStructures.DataProvidingClass
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;

    public class BigPrecision
    {
        /// <summary>
        /// Precision 5*10^-324 - > double
        /// </summary>
        private const int precision = 32;

        private BigPrecisionData data = new BigPrecisionData();
        //public static BigPrecision maxValue = new BigPrecision(new byte[] { 127, 255, 255, 255 });
        //public static BigPrecision minValue = new BigPrecision(new byte[] { 128, 0, 255, 255 });

        public BigPrecision(int n)
        {
            data.significand = new BitArray(precision);
            int pos = precision - 1;
            for (int i = 0; i < precision; ++i)
            {
                data.significand[pos] = (n & (1 << i)) != 0;
                pos--;
            }
            if (n < 0)
                data.sign = true;
        }
        public static implicit operator int(BigPrecision b)
        {
            int pow = precision - 1;
            int p = 0;
            for (int i = 0; i < precision; ++i)
            {
                if (b.data.significand[i])
                {
                    p = p | (1 << pow);
                }
                pow--;
            }
            if (b.data.sign)
                p = p * -1;
            return p;
        }

        private void CalculateAdder()
        {

        }
        private int adderToExponent = 0;
        private sealed class BigPrecisionData
        {
            public BigPrecisionData()
            {
                significand = new BitArray(precision);
                exponent = new BitArray(precision);
                sign = false;

            }
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder(precision);
                for (int i = 0; i < precision; ++i)
                {
                    builder.Append(significand[i] ? 1 : 0);
                }
                return builder.ToString();
            }

            public BitArray significand;
            public BitArray exponent;
            public bool sign;
        }
    }
}
