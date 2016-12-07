using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Api.Model;
using PassarinhoContou.Model;
using System;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly EntityEx<User> _dal = new EntityEx<User>();

        [HttpGet]
        [ActionName("All")]
        public IQueryable<User> Get()
        {
            return _dal.GetAll();
        }


        [HttpGet("{id}")]
        [ActionName("ById")]
        public IActionResult Get(int id)
        {
            var user = _dal.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{nickname}")]
        [ActionName("ByNickname")]
        public IActionResult Get(string nickname)
        {
            var user = _dal.Find(i => i.NickName == nickname);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [ActionName("BasicLogin")]
        public IActionResult Get(string email, string password)
        {
            var user = _dal.Find(i => i.Email == email);
            if (user == null)
            {
                return NotFound(new ApiResponseMessage("Email inválido"));
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        [ActionName("Edit")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        public IActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.CreationDate = DateTime.UtcNow;
            _dal.Create(user);

            return Ok(new { id = user.Id });
        }

        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var user = _dal.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            _dal.Remove(user);

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}