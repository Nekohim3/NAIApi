using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class Group : IdEntity
{
    public string  Name  { get; set; }
    public int     Order { get; set; }
    public string? Note  { get; set; }

    public                                                int     IdSession { get; set; }
    public virtual Session Session   { get; set; }

    public virtual ICollection<GroupTag> GroupTags { get; set; }
}
