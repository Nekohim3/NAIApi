using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DirsController : TController<Dir>
{
    public DirsController(TagContext ctx) : base(ctx)
    {
    }

    //public override Task<IActionResult> Get()
    //{
    //}
}
