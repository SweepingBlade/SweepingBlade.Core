namespace SweepingBlade;

public interface ICloneable<out T>
{
    T Clone();
}