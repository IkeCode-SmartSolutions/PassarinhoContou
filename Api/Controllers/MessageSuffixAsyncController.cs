using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class MessageSuffixesAsyncController : Controller
    {
        private readonly EntityEx<MessageSuffix> _dal = new EntityEx<MessageSuffix>();

        [HttpGet]
        public IQueryable<MessageSuffix> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var messageSuffix = await _dal.FindByIdAsync(id);
            if (messageSuffix == null)
            {
                return NotFound();
            }

            return Ok(messageSuffix);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MessageSuffix messageSuffix)
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
                await _dal.UpdateAsync(messageSuffix);
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
        public async Task<IActionResult> Post([FromBody]MessageSuffix messageSuffix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dal.CreateAsync(messageSuffix);

            return CreatedAtRoute("DefaultApi", new { id = messageSuffix.Id }, messageSuffix);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var messageSuffix = await _dal.FindByIdAsync(id);
            if (messageSuffix == null)
            {
                return NotFound();
            }

            await _dal.RemoveAsync(messageSuffix);

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