using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class DirTag : EntityWithoutId
{
    public         int DirsId { get; set; }
    public virtual Dir Dir    { get; set; }
    public         int TagsId { get; set; }
    public virtual Tag Tag    { get; set; }
}
