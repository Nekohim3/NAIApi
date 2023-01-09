using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Dir : IdEntity
{
    public string  Name { get; set; } = string.Empty;
    public string? Link { get; set; }
    public string? Note { get; set; }

    public int? IdParent { get; set; }

    public virtual Dir? ParentDir { get; set; }

    public virtual ICollection<Dir>? Dirs { get; set; }
    public virtual ICollection<Tag>? Tags { get; set; }
    public virtual List<DirTag>? DirTags { get; set; }
}
