using System.Diagnostics.CodeAnalysis;

namespace Hw3.Semaphore
{
    [ExcludeFromCodeCoverage]
    public class WithSemaphore : IDisposable
    {
        private static readonly string SemaphoreName = "Global\\MySemaphore__!";
        private System.Threading.Semaphore NamedSemaphore { get; init; }

        private bool _disposed;

        public const int Delay = 3000;

        public WithSemaphore()
        {
            NamedSemaphore = new System.Threading.Semaphore(1, 1, SemaphoreName);
            NamedSemaphore.WaitOne(Delay + 100);
        }

        public int Increment()
        {
            Thread.Sleep(Delay);
            return 100500;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NamedSemaphore.Release();
            _disposed = true;
        }

        ~WithSemaphore() => Dispose(false);
    }
}
