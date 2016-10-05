using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class SuffixesTranslationsController : Controller
    {
        private readonly EntityEx<SuffixTranslation> _dal = new EntityEx<SuffixTranslation>();

        [HttpGet]
        public IQueryable<SuffixTranslation> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var suffixesTranslation = _dal.FindById(id);
            if (suffixesTranslation == null)
            {
                return NotFound();
            }

            return Ok(suffixesTranslation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SuffixTranslation suffixesTranslation)
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
                _dal.Update(suffixesTranslation);
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
        public IActionResult Post([FromBody]SuffixTranslation suffixesTranslation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(suffixesTranslation);

            return Ok(new { id = suffixesTranslation.Id });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var suffixesTranslation = _dal.FindById(id);
            if (suffixesTranslation == null)
            {
                return NotFound();
            }

            _dal.Remove(suffixesTranslation);

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