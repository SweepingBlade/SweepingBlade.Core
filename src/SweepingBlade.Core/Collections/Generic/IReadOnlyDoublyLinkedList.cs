using System.Collections.Generic;

namespace SweepingBlade.Collections.Generic;

public interface IReadOnlyDoublyLinkedList<T> : IReadOnlyDoublyLinkedList, IReadOnlyCollection<T>
{
    bool Contains(T value);
    DoublyLinkedListNode<T> Find(T value);
    DoublyLinkedListNode<T> FindLast(T value);
    DoublyLinkedListNode<T> First { get; }
    DoublyLinkedListNode<T> Last { get; }
}