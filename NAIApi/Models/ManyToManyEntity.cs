using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public abstract class ManyToManyEntity<T1, T2> where T1 : IdEntity where T2 : IdEntity
{
    public int IdFirst  { get; set; }
    public int IdSecond { get; set; }
    public T1? First    { get; set; }
    public T2? Second   { get; set; }
    public static bool operator !=(ManyToManyEntity<T1,T2>? a, ManyToManyEntity<T1, T2>? b)
    {
        return !(a == b);
    }

    public static bool operator ==(ManyToManyEntity<T1, T2>? a, ManyToManyEntity<T1, T2>? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }
}
