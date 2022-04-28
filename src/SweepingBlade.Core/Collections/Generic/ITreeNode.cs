namespace SweepingBlade.Collections.Generic;

public interface ITreeNode<out T> : IReadOnlyTreeNode<T> where T : ITreeNode<T>
{
}