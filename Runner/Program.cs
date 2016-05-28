using System;
using System.Diagnostics;
using GeneratedCodeCleaner.Logic;

namespace GeneratedCodeCleaner.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(args), "You need to provide the path as the only argument.");
                }

                var watch = Stopwatch.StartNew();

                CodeCleaner.CleanDirectory(args[0]);

                watch.Stop();

                Console.WriteLine($"Processed directory '{args[0]}' in {watch.Elapsed}.");

                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.GetType());
                Console.Error.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }
        }
    }
}
