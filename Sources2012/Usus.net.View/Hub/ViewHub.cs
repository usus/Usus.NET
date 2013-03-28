using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.Hub
{
    public class ViewHub
    {
        static ViewHub instance;
        public static ViewHub Instance
        {
            get
            {
                if (instance == null) instance = new ViewHub();
                return instance;
            }
        }

        public event Action AnalysisStarted;
        public event Action<PreparedMetricsReport> MetricsReady;
        public Func<bool> ShouldUseParallelism { private get; set; }
        public PreparedMetricsReport MostRecentMetrics { get; private set; }
        readonly PreparedMetricsFactory metricsFactory;

        private ViewHub()
        {
            metricsFactory = new PreparedMetricsFactory();
            AnalysisStarted += () => analysisReady = false;
            MetricsReady += m => analysisReady = true;
            MetricsReady += m => MostRecentMetrics = m;
            ShouldUseParallelism = () => false;
        }

        bool analysisReady = true;
        public void TryStartAnalysis(IEnumerable<string> files)
        {
            if (analysisReady) StartAnalysis(files);
        }

        private void StartAnalysis(IEnumerable<string> files)
        {
            AnalysisStarted();
            var fileArray = files.ToArray();
            ThreadPool.QueueUserWorkItem((c) =>
            {
                var metrics = AnalyzeProjectFilesOrNotifyError(fileArray);
                MetricsReady(metrics);
            });
        }

        private PreparedMetricsReport AnalyzeProjectFilesOrNotifyError(string[] files)
        {
            return files.Any() ? AnalyzeProjectFiles(files) : NotifyError();
        }

        private PreparedMetricsReport AnalyzeProjectFiles(string[] files)
        {
            MetricsReport metrics = ShouldUseParallelism() ?
                AnalyzeParallel.PortableExecutables(files) :
                Analyze.PortableExecutables(files);
            return metricsFactory.Prepare(metrics);
        }

        private PreparedMetricsReport NotifyError()
        {
            MessageBox.Show("No projects found in current solution.", "No projects", MessageBoxButton.OK, MessageBoxImage.Information);
            return null;
        }
    }
}
