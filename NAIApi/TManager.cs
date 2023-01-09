using NAIApi.Models;

namespace NAIApi
{
    public static class TManager
    {
        public static int GetHash<T>(this T source) where T : class, new()
        {
            var hash = new HashCode();
            var type = source.GetType();
            while (type != typeof(IdEntity))
            {
                foreach (var p in type.GetProperties())
                {
                    if (p.CanWrite && ((!p.PropertyType.IsClass && !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType)) || p.PropertyType == typeof(string)))
                        hash.Add(p.GetValue(source, null));
                }
                if (type.BaseType == null) break;
                type = type.BaseType;
            }
            
            return hash.ToHashCode();
        }
    }
}
