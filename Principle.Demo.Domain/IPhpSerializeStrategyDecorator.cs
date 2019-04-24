namespace Principle.Demo.Domain
{
    public interface IPhpSerializeStrategyDecorator : IPhpSerializeStrategy
    {
        IPhpSerializeStrategy Context { get; set; }
    }
}