using System.Collections;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class ArrayListSerializeStrategy : ISerializeStrategy
    {
        public ISerializer Context { get; set; }

        public ArrayListSerializeStrategy(ISerializer serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            if (obj is ArrayList)
            {
                ArrayList array = (ArrayList)obj;
                sb.Append($"a:{array.Count}:{{");
                for (int key = 0; key < array.Count; key++)
                {
                    Context.Serialize(key, sb);
                    Context.Serialize(array[key], sb);
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}
