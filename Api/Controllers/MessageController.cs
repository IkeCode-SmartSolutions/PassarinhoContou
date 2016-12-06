using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PassarinhoContou.Api.Model;
using PassarinhoContou.Model;
using System;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly EntityEx<Message> _dal = new EntityEx<Message>();

        [HttpGet("{id}")]
        [ActionName("To")]
        public IActionResult GetTo(int id, int offset = 0, int limit = 15)
        {
            var messages = _dal
                            .FindAll(i => i.ToUserId == id);

            var totalCount = messages.Count();

            if (totalCount == 0)
            {
                return NoContent();
            }

            messages = messages
                            .Include(i => i.FromUser)
                            .Include(i => i.SelectedSuffix)
                            .Include(i => i.SelectedPrefix)
                            .Skip(offset)
                            .Take(limit);

            if (messages == null)
            {
                return NotFound();
            }

            var result = new ApiResponseList<Message>(messages, offset, limit, totalCount);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ActionName("From")]
        public IActionResult GetFrom(int id, int offset = 0, int limit = 15)
        {
            var messages = _dal
                            .FindAll(i => i.FromUserId == id);

            var totalCount = messages.Count();

            if (totalCount == 0)
            {
                return NoContent();
            }

            messages = messages
                            .Include(i => i.ToUser)
                            .Include(i => i.SelectedSuffix)
                            .Include(i => i.SelectedPrefix)
                            .Skip(offset)
                            .Take(limit);

            if (messages == null)
            {
                return NotFound();
            }

            var result = new ApiResponseList<Message>(messages, offset, limit, totalCount);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ActionName("Edit")]
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
        [ActionName("Add")]
        public IActionResult Post([FromBody]Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            message.CreationDate = DateTime.UtcNow;
            _dal.Create(message);

            return Ok(new { id = message.Id });
        }

        [HttpDelete("{id}")]
        [ActionName("Delete")]
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
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}