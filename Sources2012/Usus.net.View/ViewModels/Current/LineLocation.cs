
namespace andrena.Usus.net.View.ViewModels.Current
{
    public class LineLocation
    {
        public string File { get; set; }
        public int Line { get; set; }

        public bool IsSameAs(LineLocation location)
        {
            return location != null
                && location.File == File
                && location.Line == Line;
        }
    }
}
