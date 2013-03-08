using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Current
{
	public class Current : AnalysisAwareViewModel
	{
		PreparedMetricsReport metrics;

		public ObservableCollection<CurrentEntry> Entries { get; private set; }

		public IEnumerable<string> Types { get; private set; }
		private string mSelectedType;
		public string SelectedType
		{
			get { return mSelectedType; }
			set
			{
				mSelectedType = value;
				FillMethodCollection();
			}
		}

		public IEnumerable<string> Methods { get; private set; }
		private string mSelectedMethod;
		public string SelectedMethod
		{
			get { return mSelectedMethod; }
			set
			{
				mSelectedMethod = value;
				FillMethodDetails();
			}
		}

		public Current()
		{
			Entries = new ObservableCollection<CurrentEntry>();
			Types = new List<string>();
			Methods = new List<string>();
			DisplayNoMetricsInfo();
		}

		protected override void AnalysisStarted()
		{
		}

		protected override void AnalysisFinished(PreparedMetricsReport metrics)
		{
			this.metrics = metrics;
			FillTypeCollection();
		}

		private void FillTypeCollection()
		{
			Types = metrics.Report.Types.Select(t => t.FullName).OrderBy(t => t).ToList();
			Changed(() => Types);
		}

		private void FillMethodCollection()
		{
			var type = metrics.Report.ForType(SelectedType);
			Methods = metrics.Report.MethodsOfType(type).Select(m => m.Signature).ToList();
			Changed(() => Methods);
		}

		private void FillMethodDetails()
		{
			var type = metrics.Report.ForType(SelectedType);
			var methods = metrics.Report.MethodsOfType(type);
			var method = methods.FirstOrDefault(m => m.Signature == SelectedMethod);
			
			DisplayMetrics(method != null ? new MethodAndTypeMetrics(type, method) : null);
		}

		private void DisplayMetrics(MethodAndTypeMetrics method)
		{
			Entries.Clear();
			if (method == null)
				DisplayNoMetricsInfo();
			else
				DisplayMetricsInfo(method);
		}

		private void DisplayNoMetricsInfo()
		{
			Entries.Add(new CurrentEntry { Metric = "no metrics yet, consider compiling", Value = "" });
		}

		private void DisplayMetricsInfo(MethodAndTypeMetrics method)
		{
			foreach (var info in method.Info)
				Entries.Add(new CurrentEntry { Metric = info.Item1, Value = info.Item2 });
		}
	}
}
