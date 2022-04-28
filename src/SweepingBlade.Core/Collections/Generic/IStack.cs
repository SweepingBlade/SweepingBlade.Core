namespace SweepingBlade.Collections.Generic;

public interface IStack<in T> : IStack, IReadOnlyStack<T>
{
    /// <summary>
    ///     Pushes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true" /> if the item was pushed to the stack; otherwise, <see langword="false" />.</returns>
    bool Push(T item);
}