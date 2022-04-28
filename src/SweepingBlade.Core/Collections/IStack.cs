namespace SweepingBlade.Collections;

public interface IStack : IReadOnlyStack
{
    /// <summary>
    ///     Pops the item from the specified slot.
    /// </summary>
    /// <param name="slot">The slot.</param>
    bool Pop(int slot);

    /// <summary>
    ///     Pops the item from the specified slot.
    /// </summary>
    /// <param name="slot">The slot.</param>
    /// <param name="count">The count.</param>
    bool Pop(int slot, int count);
}