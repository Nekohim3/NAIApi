using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Dir : Entity
{
    public string  Name { get; set; } = string.Empty;
    public string? Link { get; set; }
    public string? Note { get; set; }

    public                                                               int? IdParent  { get; set; }
    
    [JsonIgnore]
    [ForeignKey("IdParent")] public virtual Dir? ParentDir { get; set; }

    public virtual ICollection<Dir>? Dirs { get; set; }
    public virtual ICollection<Tag>? Tags      { get; set; }
}
