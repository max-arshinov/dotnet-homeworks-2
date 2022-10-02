using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Hw3.Semaphore
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} starts");
            using var ws = new WithSemaphore();
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} acquires semaphore");
            Console.WriteLine(ws.Increment());
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} releases semaphore");
        }
    }
}