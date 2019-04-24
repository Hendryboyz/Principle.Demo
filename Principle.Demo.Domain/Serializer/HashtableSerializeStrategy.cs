using System.Collections;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class HashtableSerializeStrategy : ISerializeStrategy
    {
        public ISerializer Context { get; set; }

        public HashtableSerializeStrategy(ISerializer serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            if (obj is Hashtable)
            {
                Hashtable array = (Hashtable)obj;
                sb.Append($"a:{array.Count}:{{");
                foreach (DictionaryEntry entry in array)
                {
                    Context.Serialize(entry.Key, sb);
                    Context.Serialize(entry.Value, sb);
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}
