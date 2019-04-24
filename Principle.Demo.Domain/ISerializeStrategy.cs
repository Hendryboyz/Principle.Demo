namespace Principle.Demo.Domain
{
    public interface ISerializeStrategy
    {
        ISerializer Context { get; set; }

        string Serialize(object obj);
    }
}
