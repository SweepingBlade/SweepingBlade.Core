using System;
using System.Collections.Generic;

namespace SweepingBlade.Collections.Generic;

public sealed class KeyedCollection<TKey, TValue> : System.Collections.ObjectModel.KeyedCollection<TKey, TValue>
{
    private readonly Func<TValue, TKey> _keySelector;

    public KeyedCollection(Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer = null, int dictionaryCreationThreshold = 0)
        : base(comparer, dictionaryCreationThreshold)
    {
        _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
    }

    protected override TKey GetKeyForItem(TValue item)
    {
        return _keySelector(item);
    }
}