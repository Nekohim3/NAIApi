using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Tag : IdEntity
{
    public string  Name { get; set; } = string.Empty;
    public string? Link { get; set; }
    public string? Note { get; set; }

    public virtual ICollection<Dir>? Dirs { get; set; }
    public virtual List<DirTag>? DirTags { get; set; }
}
