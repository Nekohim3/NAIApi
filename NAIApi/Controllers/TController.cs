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
            var lst = await Context.Set<T>().AsNoTracking().ToListAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var t = await Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(_ => _.Id == id);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> Create(T t)
        {
            Context.Add(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPost]
        [Route("Bulk")]
        public async Task<IActionResult> Create(List<T> tList)
        {
            Context.AddRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPut]
        public async Task<IActionResult> Update(T t)
        {
            Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPut]
        [Route("Bulk")]
        public async Task<IActionResult> Update(List<T> tList)
        {
            Context.UpdateRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPatch]
        public async Task<IActionResult> Save(T t)
        {
            if (t.Id == 0)
                Context.Add(t);
            else
                Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPatch]
        [Route("Bulk")]
        public async Task<IActionResult> Save(List<T> tList)
        {
            var forAdd  = tList.Where(_ => _.Id == 0).ToList();
            var forSave = tList.Where(_ => _.Id != 0).ToList();
            Context.AddRange(forAdd);
            Context.UpdateRange(forSave);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await Context.Set<T>().FindAsync(id);
            if (t == null)
                return NotFound();
            Context.Remove(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete]
        [Route("Bulk")]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            var t = await Context.Set<T>().Where(_ => ids.Contains(_.Id)).ToListAsync();
            if (t.Count != ids.Count)
                return NotFound();
            Context.RemoveRange(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpGet]
        [Route("EnsureDeleted")]
        public void EnsureDeleted()
        {
            new TagContext(true);
        }
    }
}
