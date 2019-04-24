using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Principle.Demo.Domain.Serializer
{
    public class IdpMetaDataSerializeStrategy : IPhpSerializeStrategyDecorator
    {
        public IPhpSerializeStrategy Context { get; set; }

        public IdpMetaDataSerializeStrategy(IPhpSerializeStrategy serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Context.Serialize(obj));
            if (obj is IdpMetaDataResponse)
            {
                Hashtable array = ConvertMetaDataToHashtable((IdpMetaDataResponse)obj);
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

        private Hashtable ConvertMetaDataToHashtable(IdpMetaDataResponse idpMetaData)
        {
            Hashtable result = new Hashtable();
            foreach (PropertyInfo property in idpMetaData.GetType().GetProperties())
            {
                DataMemberAttribute attribute = property.GetCustomAttribute<DataMemberAttribute>(true);
                if (IsValidDataMemberAttribute(attribute))
                {
                    result.Add(attribute.Name, property.GetValue(idpMetaData));
                }
                else
                {
                    result.Add(property.Name, property.GetValue(idpMetaData));
                }
            }
            return result;
        }

        private bool IsValidDataMemberAttribute(DataMemberAttribute attribute)
        {
            return attribute != null && !string.IsNullOrEmpty(attribute.Name);
        }
    }
}
