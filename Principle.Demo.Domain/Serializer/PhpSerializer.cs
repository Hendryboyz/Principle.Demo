using System.Collections.Generic;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class PhpSerializer : ISerializer
    {
        private IList<ISerializeStrategy> _serializeStrategies;

        public PhpSerializer()
        {
            IList<ISerializeStrategy> serializeStrategies = new List<ISerializeStrategy>();
            serializeStrategies.Add(new DefaultSerializeStrategy(this));
            serializeStrategies.Add(new ArrayListSerializeStrategy(this));
            serializeStrategies.Add(new HashtableSerializeStrategy(this));
            serializeStrategies.Add(new IdpMetaDataSerializeStrategy(this));
            Initailize(serializeStrategies);

        }

        private void Initailize(IList<ISerializeStrategy> serializeStrategies)
        {
            _serializeStrategies = serializeStrategies;
        }

        public PhpSerializer(IList<ISerializeStrategy> serializeStrategies)
        {
            Initailize(serializeStrategies);
        }

        public string Serialize(object obj)
        {
            return Serialize(obj, new StringBuilder());
        }

        public string Serialize(object obj, StringBuilder sb)
        {
            if (obj is null)
            {
                sb.Append("N;");
            }
            else
            {
                foreach (ISerializeStrategy strategy in _serializeStrategies)
                {
                    sb.Append(strategy.Serialize(obj));
                }
            }
            return sb.ToString();
        }
    }
}
