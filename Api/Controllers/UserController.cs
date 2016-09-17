using Microsoft.AspNetCore.Mvc;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        //private readonly EntityEx<User> _dal = new EntityEx<User>();

        //public IQueryable<User> Get()
        //{
        //    return _dal.FindAll();
        //}

        //public IActionResult Get(int id)
        //{
        //    var user = _dal.FindById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //public IActionResult Put(int id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        _dal.Update(user);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode((int)HttpStatusCode.NoContent);
        //}

        //public IActionResult Post(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _dal.Create(user);

        //    return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        //}

        //public IActionResult Delete(int id)
        //{
        //    var user = _dal.FindById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _dal.Remove(user);

        //    return Ok(user);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _dal.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserExists(int id)
        //{
        //    return _dal.FindAll().Count(e => e.Id == id) > 0;
        //}
    }
}