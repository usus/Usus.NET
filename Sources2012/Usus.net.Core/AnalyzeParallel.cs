using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core
{
    public static class AnalyzeParallel
    {
        public static MetricsReport PortableExecutables(params string[] asmFiles)
        {
            var reports = Parallel(asmFiles, Analyze.AnalyseFile).ToArray();
            return reports.Combine();
        }

        private static IEnumerable<MetricsReport> Parallel(string[] files, Func<string, MetricsReport> fileFunction)
        {
            return from file in files.AsParallel() select fileFunction(file);
        }

        private static IEnumerable<MetricsReport> Tasks(string[] files, Func<string, MetricsReport> fileFunction)
        {
            var tasks = GetAnalyzeTasks(files, fileFunction).ToArray();
            Task.WaitAll(tasks);
            return from task in tasks select task.Result;
        }

        private static IEnumerable<Task<T>> GetAnalyzeTasks<T>(string[] files, Func<string, T> taskFunction)
        {
            return from file in files
                   select Task.Factory.StartNew(o => taskFunction(file), TaskCreationOptions.LongRunning);
        }
    }
}
