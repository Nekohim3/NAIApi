using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TagsController : TController<Tag>
{
    public TagsController(TagContext ctx) : base(ctx)
    {
    }
}
