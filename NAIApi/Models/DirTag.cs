using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NAIApi.Models;

[JsonObject]
public class DirTag : ManyToManyEntity<Dir, Tag>
{

}
