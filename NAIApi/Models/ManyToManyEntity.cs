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


    public override bool Equals(object? o)
    {
        if (o is not ManyToManyEntity<T1, T2> e)
            return false;
        if (e.IdFirst                   == 0 || IdFirst == 0 || e.IdSecond == 0 || IdSecond == 0)
            return e.GetHashCode() == GetHashCode();
        return e.IdFirst == IdFirst && e.IdSecond == IdSecond;
    }
}
