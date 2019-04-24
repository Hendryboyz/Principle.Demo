using System.Collections.Generic;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class PhpSerializer : ISerializer
    {
        private IPhpSerializeStrategy _serializeStrategy;

        public PhpSerializer()
        {
            _serializeStrategy = new DefaultSerializeStrategy();
            _serializeStrategy = new ArrayListSerializeStrategy(_serializeStrategy);
            _serializeStrategy = new HashtableSerializeStrategy(_serializeStrategy);
            _serializeStrategy = new IdpMetaDataSerializeStrategy(_serializeStrategy);
        }

        public string Serialize(object obj)
        {
            return _serializeStrategy.Serialize(obj);
        }
    }
}
