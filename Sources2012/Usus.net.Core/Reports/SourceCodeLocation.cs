
namespace andrena.Usus.net.Core.Reports
{
    public class SourceCodeLocation
    {
        public static SourceCodeLocation None { get { return new SourceCodeLocation(); } }

        public bool IsAvailable { get { return !string.IsNullOrEmpty(Filename); } }

        public string Filename { get; internal set; }
        public int Line { get; internal set; }
    }
}
