using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class SuffixesTranslationsAsyncController : Controller
    {
        private readonly EntityEx<SuffixTranslation> _dal = new EntityEx<SuffixTranslation>();

        [HttpGet]
        public IQueryable<SuffixTranslation> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var suffixesTranslation = await _dal.FindByIdAsync(id);
            if (suffixesTranslation == null)
            {
                return NotFound();
            }

            return Ok(suffixesTranslation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]SuffixTranslation suffixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suffixesTranslation.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dal.UpdateAsync(suffixesTranslation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuffixesTranslationExists(id))
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
        public async Task<IActionResult> Post([FromBody]SuffixTranslation suffixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dal.CreateAsync(suffixesTranslation);

            return CreatedAtRoute("DefaultApi", new { id = suffixesTranslation.Id }, suffixesTranslation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var suffixesTranslation = await _dal.FindByIdAsync(id);
            if (suffixesTranslation == null)
            {
                return NotFound();
            }

            await _dal.RemoveAsync(suffixesTranslation);

            return Ok(suffixesTranslation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuffixesTranslationExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}