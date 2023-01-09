using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class EntityWithoutId
{
    public static bool operator !=(EntityWithoutId? a, EntityWithoutId? b)
    {
        return !(a == b);
    }

    public static bool operator ==(EntityWithoutId? a, EntityWithoutId? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public override bool Equals(object? o)
    {
        if (o is not EntityWithoutId e)
            return false;
        return e.GetHashCode() == GetHashCode();
    }
}
