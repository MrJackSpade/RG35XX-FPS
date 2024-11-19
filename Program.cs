using FPS;

namespace RG35XX.FPS
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            FPSTester store = new();

            store.Execute();
        }
    }
}