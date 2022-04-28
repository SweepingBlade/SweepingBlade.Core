namespace SweepingBlade.Diagnostics;

public class System : ISystem
{
    private ProcessFactory _processFactory;

    public IProcessFactory Process => _processFactory ??= new ProcessFactory(this);
}