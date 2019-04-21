namespace Principle.Demo.Domain
{
    public interface IReport
    {
         void accept(IFileVisitor fileVisitor);
    }
}