using System;
using System.Threading;

namespace Hw3.Tests;

public class SingleInitializationSingleton
{
    private static readonly object Locker = new();

    private static volatile bool _isInitialized = false;

    public const int DefaultDelay = 3_000;
    
    public int Delay { get; }

    public static Lazy<SingleInitializationSingleton> lazy =
        new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton());
    public static SingleInitializationSingleton Instance => lazy.Value;
    private SingleInitializationSingleton(int delay = DefaultDelay)
    {
        Delay = delay;
        // imitation of complex initialization logic
        Thread.Sleep(delay);
    }

    internal static void Reset()
    {
        if (!_isInitialized) return;
        lock (Locker)
        {
            if(!_isInitialized) return;
            lazy = new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton());
            _isInitialized = false;
        }
    }

    public static void Initialize(int delay)
    {
        if (_isInitialized) throw new InvalidOperationException();
        lock (Locker)
        {
            if (_isInitialized) throw new InvalidOperationException();
            _isInitialized = true;
            lazy = new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton(delay));
        }
    }

}