namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Edge interface
    /// </summary>
    /// <typeparam name="T0">Type of data contained by vertices</typeparam>
    public interface IEdge<T0>
    {
        /// <summary>
        /// Returns first vertex
        /// </summary>
        IVertex<T0> First { get; }
        /// <summary>
        /// Returns second vertex
        /// </summary>
        IVertex<T0> Second { get; }
    }
}