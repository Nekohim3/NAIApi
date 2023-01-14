using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAIApi.Models;

namespace NAIApi.Controllers
{
    public abstract class TController<T> : ControllerBase where T : IdEntity
    {
        protected readonly TagContext Context;

        protected TController(TagContext ctx)
        {
            Context                                  = ctx;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            var lst = await Context.Set<T>().AsNoTracking().ToListAsync();
            return Ok(lst);
        }
        
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            var t = await Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(_ => _.Id == id);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T t)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            Context.Add(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPost]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Create(List<T> tList)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            Context.AddRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(T t)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPut]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Update(List<T> tList)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            Context.UpdateRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Save(T t)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            if (t.Id == 0)
                Context.Add(t);
            else
                Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPatch]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Save(List<T> tList)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            var forAdd  = tList.Where(_ => _.Id == 0).ToList();
            var forSave = tList.Where(_ => _.Id != 0).ToList();
            Context.AddRange(forAdd);
            Context.UpdateRange(forSave);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            var t = await Context.Set<T>().FindAsync(id);
            if (t == null)
                return NotFound();
            Context.Remove(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Delete(List<int> ids)
        {
            if (g.DatabaseSettings == null || !Context.IsValid)
                return Problem("Empty api config");
            var t = await Context.Set<T>().Where(_ => ids.Contains(_.Id)).ToListAsync();
            if (t.Count != ids.Count)
                return NotFound();
            Context.RemoveRange(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }

        //[HttpGet]
        //[Route("EnsureDeleted")]
        //public virtual void EnsureDeleted()
        //{
        //    new TagContext(true);
        //}
    }
}
