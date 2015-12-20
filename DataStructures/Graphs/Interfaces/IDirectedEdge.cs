namespace DataStructures.Graphs.Interfaces
{
    internal interface IDirectedEdge<T> : IEdge<T>
    {
        EdgeDirection EdgeDirection { get; }
    }
    /// <summary>
    /// Enum for edge's direction
    /// </summary>
    public enum EdgeDirection
    {
        /// <summary>
        /// edge is directed from first to second vertex
        /// </summary>
        Left,
        /// <summary>
        /// edge is directed from second to first vertex
        /// </summary>
        Right,
        /// <summary>
        /// edge is directed both ways
        /// </summary>
        Double
    }
}