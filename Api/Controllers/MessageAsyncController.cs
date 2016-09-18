using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesAsyncController : Controller
    {
        private readonly EntityEx<Message> _dal = new EntityEx<Message>();

        [HttpGet]
        public IQueryable<Message> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _dal.FindByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Message message)
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
                await _dal.UpdateAsync(message);
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
        public async Task<IActionResult> Post([FromBody]Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dal.CreateAsync(message);

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _dal.FindByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            await _dal.RemoveAsync(message);

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
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}