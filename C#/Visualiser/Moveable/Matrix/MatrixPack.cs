using System;namespace Visualiser.Moveable.Matrix
{
    using System.Collections;
    using System.ComponentModel;
    class MatrixPack<T> : IBindingList
    {
        private DataStructures.Matrices.Generics.Matrix<T> matrix;

        public MatrixPack(DataStructures.Matrices.Generics.Matrix<T> matrix)
        {
            this.matrix = matrix;
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count { get {return matrix.ColumnCount*matrix.RowCount}; }
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsReadOnly { get; }
        public bool IsFixedSize { get; }
        public object AddNew()
        {
            throw new NotImplementedException();
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public bool AllowNew { get; }
        public bool AllowEdit { get; }
        public bool AllowRemove { get; }
        public bool SupportsChangeNotification { get; }
        public bool SupportsSearching { get; }
        public bool SupportsSorting { get; }
        public bool IsSorted { get; }
        public PropertyDescriptor SortProperty { get; }
        public ListSortDirection SortDirection { get; }
        public event ListChangedEventHandler ListChanged;
    }
}
