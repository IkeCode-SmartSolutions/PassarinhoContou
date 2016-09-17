using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagePrefixesController : Controller
    {
        private readonly EntityEx<MessagePrefix> _dal = new EntityEx<MessagePrefix>();

        [HttpGet]
        public IQueryable<MessagePrefix> Get()
        {
            return _dal.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var messagePrefix = _dal.FindById(id);
            if (messagePrefix == null)
            {
                return NotFound();
            }

            return Ok(messagePrefix);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MessagePrefix messagePrefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messagePrefix.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(messagePrefix);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagePrefixExists(id))
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
        public IActionResult Post([FromBody]MessagePrefix messagePrefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(messagePrefix);
            
            return CreatedAtRoute("DefaultApi", new { id = messagePrefix.Id }, messagePrefix);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var messagePrefix = _dal.FindById(id);
            if (messagePrefix == null)
            {
                return NotFound();
            }

            _dal.Remove(messagePrefix);

            return Ok(messagePrefix);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessagePrefixExists(int id)
        {
            return _dal.FindAll().Count(e => e.Id == id) > 0;
        }
    }
}