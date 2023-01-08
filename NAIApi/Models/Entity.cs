using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public override bool Equals(object? o)
    {
        if (o is not Entity e)
            return false;
        if (e.Id                   == 0 && Id == 0)
            return e.GetHashCode() == GetHashCode();
        return e.Id == Id;
    }

    public override int GetHashCode() => this.GetHash();
}
