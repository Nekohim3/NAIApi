using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DirTagController : ManyToManyTController<DirTag, Dir, Tag>
{
    public DirTagController(TagContext ctx) : base(ctx)
    {
    }
}

