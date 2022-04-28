using System;

namespace SweepingBlade.Diagnostics;

public class ProcessFactory : IProcessFactory
{
    private readonly ISystem _system;

    public ProcessFactory(ISystem system)
    {
        _system = system ?? throw new ArgumentNullException(nameof(system));
    }

    public IProcess Start(string fileName)
    {
        var process = global::System.Diagnostics.Process.Start(fileName);
        return new Process(process);
    }

    public IProcess Start(string fileName, string arguments)
    {
        var process = global::System.Diagnostics.Process.Start(fileName, arguments);
        return new Process(process);
    }
}