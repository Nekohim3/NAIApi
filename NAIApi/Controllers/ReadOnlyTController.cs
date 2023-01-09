using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAIApi.Models;

namespace NAIApi.Controllers;

public abstract class ManyToManyTController<T> : ControllerBase where T : EntityWithoutId
{
    protected readonly TagContext Context;

    protected ManyToManyTController(TagContext ctx)
    {
        Context = ctx;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var lst = await Context.Set<T>().ToListAsync();
        return Ok(lst);
    }

    [HttpDelete]
    public virtual async Task<IActionResult> Delete(T t)
    {
        var e = await Context.Set<T>().FindAsync(t); 
        if (e == null)
            return NotFound();
        Context.Remove(e);
        await Context.SaveChangesAsync();
        return Ok(true);
    }

}
