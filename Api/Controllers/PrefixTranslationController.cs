using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class PrefixesTranslationsController : Controller
    {
        private readonly EntityEx<PrefixTranslation> _dal = new EntityEx<PrefixTranslation>();

        [HttpGet]
        public IQueryable<PrefixTranslation> Get()
        {
            return _dal.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prefixesTranslation = _dal.FindById(id);
            if (prefixesTranslation == null)
            {
                return NotFound();
            }

            return Ok(prefixesTranslation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PrefixTranslation prefixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prefixesTranslation.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(prefixesTranslation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefixesTranslationExists(id))
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
        public IActionResult Post([FromBody]PrefixTranslation prefixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(prefixesTranslation);

            return CreatedAtRoute("DefaultApi", new { id = prefixesTranslation.Id }, prefixesTranslation);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prefixesTranslation = _dal.FindById(id);
            if (prefixesTranslation == null)
            {
                return NotFound();
            }

            _dal.Remove(prefixesTranslation);

            return Ok(prefixesTranslation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrefixesTranslationExists(int id)
        {
            return _dal.FindAll().Count(e => e.Id == id) > 0;
        }
    }
}