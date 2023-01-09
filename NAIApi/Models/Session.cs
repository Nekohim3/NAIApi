using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Session : IdEntity
{
    public string  Name { get; set; } = string.Empty;
    public string? Note { get; set; }

    public virtual ICollection<Group> Groups { get; set; }
}
