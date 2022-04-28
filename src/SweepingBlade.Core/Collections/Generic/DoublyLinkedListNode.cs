namespace SweepingBlade.Collections.Generic;

public class DoublyLinkedListNode<T>
{
    public DoublyLinkedListNode<T> Next { get; internal set; }
    public DoublyLinkedListNode<T> Previous { get; internal set; }
    public T Value { get; }

    public DoublyLinkedListNode(T value)
    {
        Value = value;
    }

    internal void Invalidate()
    {
        Next = null;
        Previous = null;
    }
}