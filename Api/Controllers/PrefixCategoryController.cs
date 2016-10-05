using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class PrefixCategoryController : Controller
    {
        private readonly EntityEx<PrefixCategory> _dal = new EntityEx<PrefixCategory>();

        [HttpGet]
        public IQueryable<PrefixCategory> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var PrefixCategory = _dal.FindById(id);
            if (PrefixCategory == null)
            {
                return NotFound();
            }

            return Ok(PrefixCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PrefixCategory PrefixCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != PrefixCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(PrefixCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefixCategoryExists(id))
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
        public IActionResult Post([FromBody]PrefixCategory PrefixCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(PrefixCategory);

            return Ok(new { id = PrefixCategory.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var PrefixCategory = _dal.FindById(id);
            if (PrefixCategory == null)
            {
                return NotFound();
            }

            _dal.Remove(PrefixCategory);

            return Ok(PrefixCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrefixCategoryExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}