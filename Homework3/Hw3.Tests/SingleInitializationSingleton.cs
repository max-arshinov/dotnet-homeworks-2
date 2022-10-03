using System;
using System.Threading;

namespace Hw3.Tests;

public class SingleInitializationSingleton
{
    private static readonly object Locker = new();

    private static volatile bool _isInitialized = false;

    public const int DefaultDelay = 3_000;

    public int Delay { get; }

    public static SingleInitializationSingleton Instance => _lazyInstance.Value;

    private static Lazy<SingleInitializationSingleton> _lazyInstance = new(() => new SingleInitializationSingleton());

    private SingleInitializationSingleton(int delay = DefaultDelay)
    {
        Delay = delay;
        // imitation of complex initialization logic
        Thread.Sleep(delay);
    }

    internal static void Reset()
    {
        if(!_isInitialized)
            return;
        lock (Locker)
        {
            if(!_isInitialized)
                return;
            _lazyInstance = new(() => new SingleInitializationSingleton());
            _isInitialized = false;
        }
    }

    public static void Initialize(int delay)
    {
        if(_isInitialized)
            throw new InvalidOperationException("Already initialized");

        lock (Locker)
        {
            if(_isInitialized)
                throw new InvalidOperationException("Already initialized");
            _isInitialized = true;
            _lazyInstance = new(() => new SingleInitializationSingleton(delay));
        }
    }
}