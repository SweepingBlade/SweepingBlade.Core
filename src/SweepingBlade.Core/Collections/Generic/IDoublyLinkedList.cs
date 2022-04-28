namespace SweepingBlade.Collections.Generic;

public interface IDoublyLinkedList<T> : IDoublyLinkedList, IReadOnlyDoublyLinkedList<T>
{
    DoublyLinkedListNode<T> AddFirst(T value);
    DoublyLinkedListNode<T> AddLast(T value);
    void Clear();
    void RemoveFirst();
    void RemoveLast();
}