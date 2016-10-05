using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagePrefixPrefixesAsyncController : Controller
    {
        private readonly EntityEx<MessagePrefix> _dal = new EntityEx<MessagePrefix>();

        [HttpGet]
        public IQueryable<MessagePrefix> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var messagePrefix = await _dal.FindByIdAsync(id);
            if (messagePrefix == null)
            {
                return NotFound();
            }

            return Ok(messagePrefix);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MessagePrefix messagePrefix)
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
                await _dal.UpdateAsync(messagePrefix);
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
        public async Task<IActionResult> Post([FromBody]MessagePrefix messagePrefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dal.CreateAsync(messagePrefix);

            return Ok(new { id = messagePrefix.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var messagePrefix = await _dal.FindByIdAsync(id);
            if (messagePrefix == null)
            {
                return NotFound();
            }

            await _dal.RemoveAsync(messagePrefix);

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
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}