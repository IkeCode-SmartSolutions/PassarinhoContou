using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class SuffixCategoryController : Controller
    {
        private readonly EntityEx<SuffixCategory> _dal = new EntityEx<SuffixCategory>();

        [HttpGet]
        public IQueryable<SuffixCategory> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var SuffixCategory = _dal.FindById(id);
            if (SuffixCategory == null)
            {
                return NotFound();
            }

            return Ok(SuffixCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SuffixCategory SuffixCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != SuffixCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(SuffixCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuffixCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IActionResult Post([FromBody]SuffixCategory SuffixCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(SuffixCategory);

            return CreatedAtRoute("DefaultApi", new { id = SuffixCategory.Id }, SuffixCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var SuffixCategory = _dal.FindById(id);
            if (SuffixCategory == null)
            {
                return NotFound();
            }

            _dal.Remove(SuffixCategory);

            return Ok(SuffixCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuffixCategoryExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}