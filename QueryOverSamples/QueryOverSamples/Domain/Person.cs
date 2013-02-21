
namespace QueryOverSamples.Domain
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
