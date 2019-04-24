using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class DefaultSerializeStrategy : IPhpSerializeStrategy
    {
        public DefaultSerializeStrategy()
        {
        }

        public string Serialize(object obj)
        {
            if (obj is null)
            {
                return "N;";
            }
            else if (obj is string)
            {
                string str = obj as string;
                return $"s:{str.Length}:\"{str}\";";
            }
            else if (obj is bool)
            {
                bool boolean = (bool)obj;
                return string.Format("b:{0};", boolean ? 1 : 0);
            }
            else if (obj is double)
            {
                return $"d:{obj};";
            }
            else if (obj is long || obj is int)
            {
                return $"i:{obj};";
            }
            return string.Empty;
        }
    }
}
