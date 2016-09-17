using Microsoft.AspNetCore.Mvc;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersAsyncController : Controller
    {
        //private readonly EntityEx<User> _dal = new EntityEx<User>();

        //public IQueryable<User> GetUsers()
        //{
        //    return _dal.FindAll();
        //}

        //public async Task<IActionResult> Get(int id)
        //{
        //    var user = await _dal.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //public async Task<IActionResult> Put(int id, User user)
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
        //        await _dal.UpdateAsync(user);
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

        //public async Task<IActionResult> Post(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _dal.CreateAsync(user);

        //    return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var user = await _dal.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    await _dal.RemoveAsync(user);

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