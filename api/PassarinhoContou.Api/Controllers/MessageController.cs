using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly EntityEx<Message> _dal = new EntityEx<Message>();

        [HttpGet]
        public IQueryable<Message> Get()
        {
            return _dal.FindAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var message = _dal.FindById(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(message);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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
        public IActionResult Post([FromBody]Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(message);

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var message = _dal.FindById(id);
            if (message == null)
            {
                return NotFound();
            }

            _dal.Remove(message);

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return _dal.FindAll().Count(e => e.Id == id) > 0;
        }
    }
}