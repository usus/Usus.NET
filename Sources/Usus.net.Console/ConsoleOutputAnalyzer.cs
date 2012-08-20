namespace andrena.Usus.net.Console
{
    class ConsoleOutputAnalyzer : Analyzer
    {
        protected override void Output(string line)
        {
            System.Console.WriteLine(line);
        }

        protected override void Output()
        {
            Output("");
        }
    }
}
