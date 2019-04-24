using System.Collections;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class HashtableSerializeStrategy : IPhpSerializeStrategyDecorator
    {
        public IPhpSerializeStrategy Context { get; set; }

        public HashtableSerializeStrategy(IPhpSerializeStrategy serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Context.Serialize(obj));
            if (obj is Hashtable)
            {
                Hashtable array = (Hashtable)obj;
                sb.Append($"a:{array.Count}:{{");
                foreach (DictionaryEntry entry in array)
                {
                    sb.Append(Context.Serialize(entry.Key));
                    sb.Append(Context.Serialize(entry.Value));
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}
