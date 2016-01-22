using System;
namespace DataStructuresTests.Matrices
{
    struct TestStruct
    {
        static TestStruct()
        {
            MultiplyNeutral = new TestStruct(-1);
            SumNeutral = new TestStruct(2); 
        }
        private int k;
        public TestStruct(int z)
        {
            k = z;
        }

        public override string ToString()
        {
            return k.ToString();
        }

        public static readonly TestStruct MultiplyNeutral;
        public static readonly TestStruct SumNeutral;
        public static TestStruct operator -(TestStruct a)
        {
            return new TestStruct(-a.k);
        }
        public static TestStruct operator +(TestStruct a, TestStruct b)
        {
            return new TestStruct(a.k + b.k);
        }
        public static TestStruct operator -(TestStruct a, TestStruct b)
        {
            return new TestStruct(a.k - b.k);
        }
        public static TestStruct operator *(TestStruct a, TestStruct b)
        {
            return new TestStruct(a.k * b.k);
        }
        public static TestStruct operator /(TestStruct a, TestStruct b)
        {
            return new TestStruct(a.k / b.k);
        }
        public static bool operator ==(TestStruct a, TestStruct b)
        {
            return a.k == b.k;
        }
        public static bool operator !=(TestStruct a, TestStruct b)
        {
            return !(a == b);
        }
    }
}
