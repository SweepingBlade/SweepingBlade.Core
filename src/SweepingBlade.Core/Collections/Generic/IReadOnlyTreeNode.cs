using System.Collections.Generic;

namespace SweepingBlade.Collections.Generic;

public interface IReadOnlyTreeNode<out T> : IEnumerable<T>, IReadOnlyTreeNode where T : IReadOnlyTreeNode<T>
{
    IEnumerable<T> Nodes { get; }
    T Parent { get; }
}