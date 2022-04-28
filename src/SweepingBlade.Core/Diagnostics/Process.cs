using System;

namespace SweepingBlade.Diagnostics;

public sealed class Process : IProcess
{
    private readonly global::System.Diagnostics.Process _process;

    public Process(global::System.Diagnostics.Process process)
    {
        _process = process ?? throw new ArgumentNullException(nameof(process));
    }
}