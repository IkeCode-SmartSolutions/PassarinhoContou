using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessageSuffixController : Controller
    {
        private readonly EntityEx<MessageSuffix> _dal = new EntityEx<MessageSuffix>();

        [HttpGet]
        public IQueryable<MessageSuffix> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var messageSuffix = _dal.FindAll(i => i.SuffixCategoryId == categoryId);
            if (messageSuffix == null)
            {
                return NotFound();
            }

            return Ok(messageSuffix);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MessageSuffix messageSuffix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messageSuffix.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(messageSuffix);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageSuffixExists(id))
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
        public IActionResult Post([FromBody]MessageSuffix messageSuffix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(messageSuffix);

            return CreatedAtRoute("DefaultApi", new { id = messageSuffix.Id }, messageSuffix);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var messageSuffix = _dal.FindById(id);
            if (messageSuffix == null)
            {
                return NotFound();
            }

            _dal.Remove(messageSuffix);

            return Ok(messageSuffix);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageSuffixExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}