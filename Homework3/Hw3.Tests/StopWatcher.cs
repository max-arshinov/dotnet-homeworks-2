using System;
using System.Diagnostics;

namespace Hw3.Tests;

public static class StopWatcher
{
    /// <summary>
    /// For quick tests only. For benchmarks use
    /// https://benchmarkdotnet.org/
    /// </summary>
    public static TimeSpan Stopwatch(Action action)
    {
        var sw = new Stopwatch();
        sw.Start();
        action();
        sw.Stop();
        return sw.Elapsed;
    }
}