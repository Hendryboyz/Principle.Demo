using System.Collections;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class ArrayListSerializeStrategy : IPhpSerializeStrategyDecorator
    {
        public IPhpSerializeStrategy Context { get; set; }

        public ArrayListSerializeStrategy(IPhpSerializeStrategy serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Context.Serialize(obj));
            if (obj is ArrayList)
            {
                ArrayList array = (ArrayList)obj;
                sb.Append($"a:{array.Count}:{{");
                for (int key = 0; key < array.Count; key++)
                {
                    sb.Append(Context.Serialize(key));
                    sb.Append(Context.Serialize(array[key]));
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}
