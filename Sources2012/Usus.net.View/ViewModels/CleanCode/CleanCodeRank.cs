using System.Collections.ObjectModel;
using System.Windows.Media;

namespace andrena.Usus.net.View.ViewModels.CleanCode
{
    public class CleanCodeRank
    {
        public SolidColorBrush Color { get; set; }
        public string Name { get; set; }
        public ObservableCollection<CleanCodePrinciple> Principles { get; set; }
        public ObservableCollection<CleanCodePractice> Practices { get; set; }

        public CleanCodeRank(Color color, string name)
        {
            Color = new SolidColorBrush(color);
            Name = "  " + name;
            Principles = new ObservableCollection<CleanCodePrinciple>();
            Practices = new ObservableCollection<CleanCodePractice>();
        }
    }
}
