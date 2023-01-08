using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Group : Entity
{
    public string  Name  { get; set; }
    public int     Order { get; set; }
    public string? Note  { get; set; }

    public                                                int     IdSession { get; set; }
    [JsonIgnore] [ForeignKey("IdSession")] public virtual Session Session   { get; set; }

    public virtual ICollection<GroupTag> GroupTags { get; set; }
}
