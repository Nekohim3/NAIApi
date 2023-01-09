using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public abstract class IdEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public static bool operator !=(IdEntity? a, IdEntity? b)
    {
        return !(a == b);
    }

    public static bool operator ==(IdEntity? a, IdEntity? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public override bool Equals(object? o)
    {
        if (o is not IdEntity e)
            return false;
        if (e.Id                   == 0 && Id == 0)
            return e.GetHashCode() == GetHashCode();
        return e.Id == Id;
    }
}
