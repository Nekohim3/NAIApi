using Microsoft.AspNetCore.Mvc;
using NAIApi.Models;

namespace NAIApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionsController : TController<Session>
{
    public SessionsController(TagContext ctx) : base(ctx)
    {
    }
}

