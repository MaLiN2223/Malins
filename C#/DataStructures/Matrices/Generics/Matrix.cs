namespace DataStructures.Matrices.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    #region helpers

    internal interface ITypeTratis<T>
    {
        T MultiplyNeutral { get; set; }
        T SumNeutral { get; set; }
        T Add(T a, T b);
        T Mul(T a, T b);
        T Sub(T a, T b);
        T Div(T a, T b);
        bool Eq(T a, T b);
        T Neg(T a);
    }

    internal class IntTypeTratis : ITypeTratis<int>
    {
        private static int _multiplyNeutralF = 1;
        private static int _sumNeutralF;
        public int Add(int a, int b) => a + b;

        public int Mul(int a, int b) => a * b;

        public int Sub(int a, int b) => a - b;

        public int Div(int a, int b) => a / b;
        public bool Eq(int a, int b) => a == b;
        public int Neg(int a) => -a;

        public int MultiplyNeutral
        {
            get { return _multiplyNeutralF; }
            set { _multiplyNeutralF = value; }
        }

        public int SumNeutral
        {
            get { return _sumNeutralF; }
            set { _sumNeutralF = value; }
        }
    }

    internal class DoubleTypeTratis : ITypeTratis<double>
    {
        private static double _multiplyNeutralF = 1.0;
        private static double _sumNeutralF = 0.0;
        public double Add(double a, double b) => a + b;

        public double Mul(double a, double b) => a * b;

        public double Sub(double a, double b) => a - b;

        public double Div(double a, double b) => a / b;
        public bool Eq(double a, double b) => Math.Abs(a - b) < double.Epsilon;
        public double Neg(double a) => -a;

        public double MultiplyNeutral
        {
            get { return _multiplyNeutralF; }
            set { _multiplyNeutralF = value; }
        }

        public double SumNeutral
        {
            get { return _sumNeutralF; }
            set { _sumNeutralF = value; }
        }
    }

    internal class TypeTraits<T> : ITypeTratis<T>
    {
        internal Func<T, T, T> AddF;
        internal Func<T, T, T> DivF;
        internal Func<T, T, bool> EqF;
        internal Func<T, T, T> MulF;
        internal T MultiplyNeutralF;
        internal Func<T, T> NegF;
        internal Func<T, T, T> SubF;
        internal T SumNeturalF;
        public T Add(T a, T b) => AddF(a, b);

        public bool Eq(T a, T b) => EqF(a, b);

        public T Mul(T a, T b) => MulF(a, b);

        public T Sub(T a, T b) => SubF(a, b);

        public T Div(T a, T b) => DivF(a, b);
        public T Neg(T a) => NegF(a);

        public T MultiplyNeutral
        {
            get { return MultiplyNeutralF; }
            set { MultiplyNeutralF = value; }
        }

        public T SumNeutral
        {
            get { return SumNeturalF; }
            set { SumNeturalF = value; }
        }
    }

    #endregion
    [DebuggerDisplay("Matrix rows={RowCount}, columns={ColumnCount}, type = {typeof(T)}")]
    [Serializable]
    public class Matrix<T> where T : struct
    {
        private readonly MatrixContainer<T> container;
        internal Matrix(int rows, int columns)
        {
            container = new MatrixContainer<T>(rows, columns);
        }

        internal Matrix(MatrixContainer<T> container)
        {
            this.container = container;
        }

        public int RowCount => container.RowCount;
        public int ColumnCount => container.ColumnCount;

        public override bool Equals(object obj)
        {
            var comp = obj as Matrix<T>;
            if (comp == null)
                return false;
            if (comp.RowCount != RowCount)
                return false;
            if (comp.ColumnCount != ColumnCount)
                return false;
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    if (!this[i, j].Equals(comp[i, j]))
                        return false;
                }
            }
            return true;
        }

        public static bool operator ==(Matrix<T> first, Matrix<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;
            if (first.RowCount != second.RowCount)
                return false;
            if (first.ColumnCount != second.ColumnCount)
                return false;
            for (var i = 0; i < first.RowCount; i++)
            {
                for (var j = 0; j < second.ColumnCount; j++)
                {
                    if (!Eq(first[i, j], second[i, j]))
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrix<T> first, Matrix<T> second)
        {
            return !(first == second);
        }
        public T this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return container[row, column]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { container[row, column] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException();
            var array = new T[first.RowCount, first.ColumnCount];
            for (var i = 0; i < first.RowCount; ++i)
                for (var k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = Sum(first[i, k], second[i, k]);
            return Factory<T>.Create(array);
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException();
            var array = new T[first.RowCount, first.ColumnCount];
            for (var i = 0; i < first.RowCount; ++i)
                for (var k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = Sub(first[i, k], second[i, k]);
            return Factory<T>.Create(array);
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.RowCount)
                throw new ArgumentException("Matrices must have good dimensions");
            var mOut = Factory<T>.Create(first.RowCount, second.ColumnCount);
            for (var i = 0; i < mOut.RowCount; i++)
            {
                for (var j = 0; j < mOut.ColumnCount; j++)
                {
                    for (var k = 0; k < second.RowCount; k++)
                    {
                        mOut[i, j] = Sum(mOut[i, j], Mul(first[i, k], second[k, j]));
                    }
                }
            }
            return mOut;
        }

        public static Matrix<T> operator -(Matrix<T> first)
        {
            if (ReferenceEquals(first, null))
                throw new NullReferenceException();
            var output = new Matrix<T>(first.RowCount, first.ColumnCount);
            for (var i = 0; i < first.RowCount; i++)
            {
                for (var j = 0; j < first.ColumnCount; j++)
                {
                    output[i, j] = Neg(first[i, j]);
                }
            }
            return output;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder((RowCount + 2) * (ColumnCount + 2));
            for (int i = 0; i < RowCount; ++i)
            {
                builder.Append('-');
            }
            for (int i = 0; i < RowCount; ++i)
            {
                builder.Append('|');
                for (int j = 0; j < ColumnCount; ++j)
                {
                    builder.Append(this[i, j]).Append(' ');
                }
                builder.Append('|');
            }
            return builder.ToString();

        }

        public void Negate()
        {
            try
            {
                for (var i = 0; i < RowCount; i++)
                {
                    for (var j = 0; j < ColumnCount; j++)
                    {
                        this[i, j] = Neg(this[i, j]);
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw new NotSupportedException($"Type {typeof(T)} does not support negation");
            }
        }

        public T Determinant()
        {
            if (RowCount != ColumnCount)
                throw new InvalidOperationException("Matrix must be square");
            return default(T);
        }

        #region RTTI

        private static readonly IDictionary<Type, object> traitByType = new Dictionary<Type, object>
        {
            {typeof (int), new IntTypeTratis()},
            {typeof (double), new DoubleTypeTratis()}
        };

        public static T MultiplyNeutral
        {
            get { return ((ITypeTratis<T>)traitByType[typeof(T)]).MultiplyNeutral; }
            set { ((ITypeTratis<T>)traitByType[typeof(T)]).MultiplyNeutral = value; }
        }

        public static T SumNeutral
        {
            get { return ((ITypeTratis<T>)traitByType[typeof(T)]).SumNeutral; }
            set { ((ITypeTratis<T>)traitByType[typeof(T)]).SumNeutral = value; }
        }

        static Matrix()
        {
            var type = typeof(T);
            if (!traitByType.ContainsKey(type))
            {
                var arr = new Type[] { type, type };
                MethodInfo add, sub, mul, div, eq;
                FieldInfo mulN, addN;
                if ((add = type.GetMethod("op_Addition", arr)) == null)
                    throw new NotSupportedException("Addition is not implemented");
                if ((sub = type.GetMethod("op_Subtraction", arr)) == null)
                    throw new NotSupportedException("Substraction is not implemented");
                if ((mul = type.GetMethod("op_Multiply", arr)) == null)
                    throw new NotSupportedException("Multiply is not implemented");
                if ((div = type.GetMethod("op_Division", arr)) == null)
                    throw new NotSupportedException("Division is not implemented");
                if ((eq = type.GetMethod("op_Equality", arr)) == null)
                    throw new NotSupportedException("Equality is not implemented");
                var neg = type.GetMethod("op_Negate");
                mulN = type.GetField("MultiplyNeutral", BindingFlags.Static | BindingFlags.Public);
                addN = type.GetField("SumNeutral", BindingFlags.Static | BindingFlags.Public);
                var obj = new TypeTraits<T>
                {
                    AddF = (a, b) => (T)add.Invoke(null, new object[] { a, b }),
                    SubF = (a, b) => (T)sub.Invoke(null, new object[] { a, b }),
                    MulF = (a, b) => (T)mul.Invoke(null, new object[] { a, b }),
                    DivF = (a, b) => (T)div.Invoke(null, new object[] { a, b }),
                    EqF = (a, b) => (bool)eq.Invoke(null, new object[] { a, b }),
                    NegF = a => (T)neg.Invoke(null, new object[] { a })

                };
                if (mulN != null)
                    obj.MultiplyNeutralF = (T)mulN.GetValue(null);
                if (addN != null)
                    obj.SumNeturalF = (T)addN.GetValue(null);
                traitByType[type] = obj;
            }
        }

        private static T Sum(T a, T b) => ((ITypeTratis<T>)traitByType[typeof(T)]).Add(a, b);
        private static T Sub(T a, T b) => ((ITypeTratis<T>)traitByType[typeof(T)]).Sub(a, b);
        private static T Mul(T a, T b) => ((ITypeTratis<T>)traitByType[typeof(T)]).Mul(a, b);
        private static T Div(T a, T b) => ((ITypeTratis<T>)traitByType[typeof(T)]).Div(a, b);
        private static bool Eq(T a, T b) => ((ITypeTratis<T>)traitByType[typeof(T)]).Eq(a, b);
        private static T Neg(T a) => ((ITypeTratis<T>)traitByType[typeof(T)]).Neg(a);

        #endregion
    }
}