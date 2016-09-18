using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class PrefixesTranslationsAsyncController : Controller
    {
        private readonly EntityEx<PrefixTranslation> _dal = new EntityEx<PrefixTranslation>();

        [HttpGet]
        public IQueryable<PrefixTranslation> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prefixesTranslation = await _dal.FindByIdAsync(id);
            if (prefixesTranslation == null)
            {
                return NotFound();
            }

            return Ok(prefixesTranslation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PrefixTranslation prefixesTranslation)
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
                await _dal.UpdateAsync(prefixesTranslation);
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
        public async Task<IActionResult> Post([FromBody]PrefixTranslation prefixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dal.CreateAsync(prefixesTranslation);

            return CreatedAtRoute("DefaultApi", new { id = prefixesTranslation.Id }, prefixesTranslation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prefixesTranslation = await _dal.FindByIdAsync(id);
            if (prefixesTranslation == null)
            {
                return NotFound();
            }

            await _dal.RemoveAsync(prefixesTranslation);

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
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}