using System.Text;

namespace Principle.Demo.Domain
{
    public interface ISerializer
    {
        string Serialize(object obj);

        string Serialize(object obj, StringBuilder sb);
    }
}
