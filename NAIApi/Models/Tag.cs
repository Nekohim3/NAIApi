using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Tag : Entity
{
    public string  Name { get; set; } = string.Empty;
    public string? Link { get; set; }
    public string? Note { get; set; }

    public int IdDir { get; set; }
    
    [JsonIgnore]
    [ForeignKey("IdDir")] public virtual Dir? Dir   { get; set; }
}
