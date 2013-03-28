
namespace andrena.Usus.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /* •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
               | //Analyze Usus.net itself                                                                                                            |
               | new ConsoleOutputAnalyzer().AnalyzeFile(@"D:\manuel\Git\GitHub\MTSS12\source\Usus.net\Usus.net.Core\bin\Debug\Usus.net.Core.dll"); |
               •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

            if (HelpRequested(args))
                PrintHelp(args);
            else
                Analysis(args);
        }

        private static void Analysis(string[] args)
        {
            Analyzer analyzer = new ConsoleOutputAnalyzer();
            if (args.Length == 0) analyzer.AnalyzeThisAssembly();
            if (args.Length == 1) analyzer.AnalyzeFile(args[0]);
        }

        private static bool HelpRequested(string[] args)
        {
            return args.Length == 1 && args[0].Contains("?");
        }

        private static void PrintHelp(string[] args)
        {
            System.Console.WriteLine("Usus.net.Console.exe <assemblyPath>");
        }
    }
}
