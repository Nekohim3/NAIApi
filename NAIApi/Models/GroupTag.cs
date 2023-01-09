using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class GroupTag : IdEntity
{
    public int Order    { get; set; }
    public int Strength { get; set; }

    public                                             int   IdGroup { get; set; }
    [JsonIgnore] public virtual Group Group   { get; set; }

    public                                            int IdTag { get; set; }
    [JsonIgnore] public virtual Tag Tag   { get; set; }
}
