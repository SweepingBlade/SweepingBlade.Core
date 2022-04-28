namespace SweepingBlade.Diagnostics;

public interface IProcessFactory
{
    IProcess Start(string fileName);
    IProcess Start(string fileName, string arguments);
}