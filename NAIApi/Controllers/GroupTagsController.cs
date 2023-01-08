using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupTagsController : TController<GroupTag>
{
    public GroupTagsController(TagContext ctx) : base(ctx)
    {
    }
}

