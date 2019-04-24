namespace Principle.Demo.Domain.Serializer
{
    public class DefaultSerializeStrategy : ISerializeStrategy
    {
        public ISerializer Context { get; set; }

        public DefaultSerializeStrategy(ISerializer serializer)
        {
            Context = serializer;
        }

        public string Serialize(object obj)
        {
            if (obj is string)
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
