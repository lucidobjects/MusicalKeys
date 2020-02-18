using System;
using System.Diagnostics;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press <Enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}
