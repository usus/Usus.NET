using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using andrena.Usus.net.Core.Helper;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SqiHistory
    {
        private string _solution;
        public ObservableCollection<KeyValuePair<DateTime, double>> PointsInTime { get; private set; }

        public SqiHistory()
        {
            PointsInTime = new ObservableCollection<KeyValuePair<DateTime, double>>();
        }

        public void Now(double currentSqi, string solution)
        {
            if (!string.IsNullOrEmpty(solution))
                EnsureSolutionContext(solution);
            StorePoint(DateTime.Now, currentSqi);
        }

        private void EnsureSolutionContext(string solution)
        {
            if (_solution != solution)
            {
                _solution = solution;
                LoadPreviousPoints();
            }
        }

        private void LoadPreviousPoints()
        {
            PointsInTime.Clear();
            foreach (var sqiFile in PreviousSqiFiles) LoadSqiFrom(sqiFile);
        }

        private void LoadSqiFrom(string sqiFile)
        {
            try
            {
                PointsInTime.Add(ParseSqiAndTime(sqiFile));
            }
            catch (Exception)
            { }
        }

        private KeyValuePair<DateTime, double> ParseSqiAndTime(string sqiFile)
        {
            var sqi = Convert.ToDouble(File.ReadAllText(sqiFile), CultureInfo.InvariantCulture); 
            var time = new DateTime(long.Parse(Path.GetFileNameWithoutExtension(sqiFile)));
            return time.WithValue(sqi);
        }

        private void StorePoint(DateTime time, double sqi)
        {
            PointsInTime.Add(time.WithValue(sqi));
            if (!string.IsNullOrEmpty(_solution))
                File.WriteAllText(Path.Combine(SqiFolder, time.Ticks + ".sqi"), Convert.ToString(sqi, CultureInfo.InvariantCulture));
        }

        private string SqiFolder
        {
            get
            {
                var sqiFolder = Path.Combine(Path.GetDirectoryName(_solution), "_sqi");
                if (!Directory.Exists(sqiFolder)) Directory.CreateDirectory(sqiFolder);
                return sqiFolder;
            }
        }

        private IEnumerable<string> PreviousSqiFiles
        {
            get { return Directory.EnumerateFiles(SqiFolder, "*.sqi").OrderByDescending(f => f).Take(100); }
        }
    }
}
