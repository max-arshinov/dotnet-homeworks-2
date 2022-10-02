using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hw3.Tests;

public class SingleInitializationSingletonTests
{
    [Fact]
    public void Initialize_DoesNotCreateInstance()
    {
        SingleInitializationSingleton.Reset();
        int delay = 20000;

        var elapsed = StopWatcher.Stopwatch(() =>
        {
            SingleInitializationSingleton.Initialize(delay);
        });

        Assert.True(elapsed.TotalMilliseconds < delay);
    }


    [Fact]
    public void NegativeDelayThrowsException()
    {
        SingleInitializationSingleton.Reset();
        int delay = -20;

        Action checkForException = () => SingleInitializationSingleton.Initialize(delay);

        Assert.Throws<ArgumentException>(checkForException);
    }

    [Fact]
    public void TasksCreateInstanceOnce()
    {
        SingleInitializationSingleton.Reset();
        int delay = 3000;
        int count = 50;
        var tasks = new Task[count];
        var getInstanceTimes = new double[count];
        var instances = new SingleInitializationSingleton[count];
        var startEvent = new ManualResetEvent(false);
        SingleInitializationSingleton.Initialize(delay);
        for(int i = 0; i < count; i++)
        {
            var elem = i;
            var t = new Task(() =>
            {
                startEvent.WaitOne();
                SingleInitializationSingleton instance = null;
                var ellapsed = GetEllapsedMilliseconds(() => instance = SingleInitializationSingleton.Instance);
                instances[elem] = instance!;
                getInstanceTimes[elem] = ellapsed;
            });
            tasks[i] = t;
            t.Start();
        }

        startEvent.Set();
        Task.WaitAll(tasks);
        var firstInstance = instances[0];

        for(var i = 1; i < count; i++)
        {
            Assert.True(firstInstance == instances[i]);
            Assert.True(getInstanceTimes[i] -delay <= 150);
        }
    } 

    [Fact]
    public void DefaultInitialization_ReturnsSingleInstance()
    {
        SingleInitializationSingleton.Reset();
        SingleInitializationSingleton? i1 = null;
        var elapsed = GetEllapsedMilliseconds(() =>
        {
            i1 = SingleInitializationSingleton.Instance;
        });

        var i2 = SingleInitializationSingleton.Instance;
        Assert.Equal(i2, i1);

        Assert.True(elapsed >= i2.Delay);
    }

    [Fact]
    public void CustomInitialization_ReturnsSingleInstance()
    {
        SingleInitializationSingleton.Reset();
        var delay = 5_000;
        SingleInitializationSingleton.Initialize(delay);
        var elapsed = GetEllapsedMilliseconds(() =>
        {
            var i = SingleInitializationSingleton.Instance;
            Assert.Equal(i, SingleInitializationSingleton.Instance);
        });

        Assert.True(elapsed > SingleInitializationSingleton.DefaultDelay);
        Assert.True(elapsed >= delay);
    }

    [Fact]
    public void DoubleInitializationAttemptThrowsException()
    {
        SingleInitializationSingleton.Reset();

        SingleInitializationSingleton.Initialize(2);

        Assert.Throws<InvalidOperationException>(() =>
        {
            SingleInitializationSingleton.Initialize(3);
        });
    }

    private double GetEllapsedMilliseconds(Action action)
    {
        return StopWatcher.Stopwatch(action).TotalMilliseconds;
    }
}