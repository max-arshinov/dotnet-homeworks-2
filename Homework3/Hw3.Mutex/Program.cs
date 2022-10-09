using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Hw3.Mutex
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} starts");
            using var wm = new WithMutex();
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} acquires mutex");
            Console.WriteLine(wm.Increment());
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {Process.GetCurrentProcess().Id} releases mutex");
        }
    }
}
