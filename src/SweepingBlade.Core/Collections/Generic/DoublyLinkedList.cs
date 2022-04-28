using System;
using System.Collections;
using System.Collections.Generic;

namespace SweepingBlade.Collections.Generic;

public class DoublyLinkedList<T> : IDoublyLinkedList<T>
{
    public DoublyLinkedList()
    {
    }

    public DoublyLinkedList(IEnumerable<T> collection)
    {
        if (collection is null) throw new ArgumentNullException(nameof(collection));
        foreach (var item in collection)
        {
            AddLast(item);
        }
    }

    public int Count { get; private set; }

    public DoublyLinkedListNode<T> First { get; private set; }

    public DoublyLinkedListNode<T> Last { get; private set; }

    public DoublyLinkedListNode<T> AddFirst(T value)
    {
        var node = new DoublyLinkedListNode<T>(value);

        if (First is null)
        {
            InternalAddNodeToEmptyList(node);
        }
        else
        {
            InternalAddNodeBefore(First, node);
            First = node;
        }

        return node;
    }

    public DoublyLinkedListNode<T> AddLast(T value)
    {
        var node = new DoublyLinkedListNode<T>(value);

        if (First is null)
        {
            InternalAddNodeToEmptyList(node);
        }
        else
        {
            InternalAddNodeAfter(Last, node);
            Last = node;
        }

        return node;
    }

    public void Clear()
    {
        var node = First;
        while (node is not null)
        {
            var tempNode = node;
            node = node.Next;
            tempNode.Invalidate();
        }

        First = null;
        Last = null;
        Count = 0;
    }

    public void RemoveFirst()
    {
        InternalRemoveNode(First);
    }

    public void RemoveLast()
    {
        InternalRemoveNode(Last);
    }

    public IEnumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }

    public bool Contains(T value)
    {
        return Find(value) is not null;
    }

    public DoublyLinkedListNode<T> Find(T value)
    {
        var firstNode = First;
        if (firstNode is null) return null;

        if (value is not null)
        {
            var equalityComparer = EqualityComparer<T>.Default;
            while (!equalityComparer.Equals(firstNode.Value, value))
            {
                firstNode = firstNode.Next;
                if (firstNode == First)
                {
                    return null;
                }
            }

            return firstNode;
        }

        while (firstNode.Value is not null)
        {
            firstNode = firstNode.Next;
            if (firstNode == First)
            {
                return null;
            }
        }

        return firstNode;
    }

    public DoublyLinkedListNode<T> FindLast(T value)
    {
        if (First is null)
        {
            return null;
        }

        var previous = Last;
        var last = previous;
        if (last is null)
        {
            return null;
        }

        if (value is not null)
        {
            var equalityComparer = EqualityComparer<T>.Default;
            while (!equalityComparer.Equals(last.Value, value))
            {
                last = last.Previous;
                if (last == previous)
                {
                    return null;
                }
            }

            return last;
        }

        while (last.Value is not null)
        {
            last = last.Previous;
            if (last == previous)
            {
                return null;
            }
        }

        return last;
    }

    private void InternalAddNodeAfter(DoublyLinkedListNode<T> node, DoublyLinkedListNode<T> newNode)
    {
        newNode.Previous = node;
        newNode.Next = node.Next;

        if (node.Next is not null)
        {
            node.Next.Previous = newNode;
        }

        node.Next = newNode;
        ++Count;
    }

    private void InternalAddNodeBefore(DoublyLinkedListNode<T> node, DoublyLinkedListNode<T> newNode)
    {
        newNode.Previous = node.Previous;
        newNode.Next = node;

        if (newNode.Previous is not null)
        {
            newNode.Previous.Next = newNode;
        }

        node.Previous = newNode;
        ++Count;
    }

    private void InternalAddNodeToEmptyList(DoublyLinkedListNode<T> newNode)
    {
        First = newNode;
        Last = newNode;
        ++Count;
    }

    private void InternalRemoveNode(DoublyLinkedListNode<T> node)
    {
        if (node.Next == node)
        {
            First = null;
        }
        else
        {
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            if (First == node)
            {
                First = node.Next;
            }
        }

        node.Invalidate();
        --Count;
    }

    private struct Enumerator : IEnumerator<T>
    {
        private readonly DoublyLinkedList<T> _list;
        private DoublyLinkedListNode<T> _node;
        private int _index;

        public Enumerator(DoublyLinkedList<T> list)
        {
            _list = list;
            _node = list.First;
            Current = default;
            _index = 0;
        }

        public T Current { get; private set; }

        object IEnumerator.Current
        {
            get
            {
                if (_index == 0 || _index == _list.Count + 1)
                {
                    throw new InvalidOperationException("Enumeration operation cannot happen");
                }

                return Current;
            }
        }

        public bool MoveNext()
        {
            if (_node is null)
            {
                _index = _list.Count + 1;
                return false;
            }

            ++_index;
            Current = _node.Value;
            _node = _node.Next;

            return true;
        }

        void IEnumerator.Reset()
        {
            Current = default;
            _node = _list.First;
            _index = 0;
        }

        public void Dispose()
        {
        }
    }
}