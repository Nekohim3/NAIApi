using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupsController : TController<Group>
{
    public GroupsController(TagContext ctx) : base(ctx)
    {
    }
}

