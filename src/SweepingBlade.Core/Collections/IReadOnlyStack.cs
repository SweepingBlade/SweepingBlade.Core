using System.Collections;

namespace SweepingBlade.Collections;

public interface IReadOnlyStack : IEnumerable
{
    /// <summary>
    ///     Gets the item count.
    /// </summary>
    /// <value>The item count.</value>
    int Count { get; }
}