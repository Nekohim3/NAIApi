using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class GroupTag : Entity
{
    public int Order    { get; set; }
    public int Strength { get; set; }

    public                                             int   IdGroup { get; set; }
    [JsonIgnore] [ForeignKey("IdGroup")] public virtual Group Group   { get; set; }

    public                                            int IdTag { get; set; }
    [JsonIgnore] [ForeignKey("IdTag")] public virtual Tag Tag   { get; set; }
}
