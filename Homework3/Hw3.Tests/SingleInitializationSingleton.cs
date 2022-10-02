using System;
using System.Threading;

namespace Hw3.Tests;

public class SingleInitializationSingleton
{
    private static readonly object Locker = new();

    private static volatile bool _isInitialized = false;

    public const int DefaultDelay = 3_000;

    public int Delay { get; }

    private static Lazy<SingleInitializationSingleton> _instanse = new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton());

    private SingleInitializationSingleton(int delay = DefaultDelay)
    {
        Delay = delay;
        Thread.Sleep(delay);
    }

    internal static void Reset()
    {
        if(_isInitialized)
            lock (Locker)
            {
                if (_isInitialized)
                {
                    _instanse = new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton());
                    _isInitialized = false;
                }
            }
    }

    public static void Initialize(int delay)
    {
        if (!_isInitialized)
            lock (Locker)
            {
                if (!_isInitialized)
                {
                    _instanse = new Lazy<SingleInitializationSingleton>(() => new SingleInitializationSingleton(delay));
                    _isInitialized = true;
                    return;
                }
            }
        throw new InvalidOperationException();
    }

   
    public static SingleInitializationSingleton Instance 
    {
        get
        {
            lock(Locker)
                return _instanse.Value;
        }
    }
}