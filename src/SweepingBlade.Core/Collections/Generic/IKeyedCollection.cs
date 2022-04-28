using System.Collections.Generic;

namespace SweepingBlade.Collections.Generic;

public interface IKeyedCollection<in TKey, TValue> : IReadOnlyCollection<TValue>
{
    void Add(TValue value);
    void Clear();
    bool Contains(TKey key);
    TValue GetValue(TKey value);
    int IndexOf(TValue item);
    void Insert(int index, TValue item);
    void Move(int oldIndex, int newIndex);
    bool Remove(TKey key);
    bool Remove(TValue value);
    bool TryGetValue(TKey key, out TValue value);
}