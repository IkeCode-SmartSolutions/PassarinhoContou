using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassarinhoContou.Model;
using System.Linq;
using System.Net;

namespace PassarinhoContouApi.Controllers
{
    [Route("api/ConnectedDevices")]
    public class ConnectedDevicesController : Controller
    {
        private readonly EntityEx<ConnectedDevice> _dal = new EntityEx<ConnectedDevice>();

        [HttpGet]
        public IQueryable<ConnectedDevice> Get()
        {
            return _dal.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var connectedDevice = _dal.FindById(id);
            if (connectedDevice == null)
            {
                return NotFound();
            }

            return Ok(connectedDevice);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ConnectedDevice connectedDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connectedDevice.Id)
            {
                return BadRequest();
            }

            try
            {
                _dal.Update(connectedDevice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectedDeviceExists(id))
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
        public IActionResult Post([FromBody]ConnectedDevice connectedDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dal.Create(connectedDevice);

            return Ok(new { id = connectedDevice.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var connectedDevice = _dal.FindById(id);
            if (connectedDevice == null)
            {
                return NotFound();
            }

            _dal.Remove(connectedDevice);

            return Ok(connectedDevice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConnectedDeviceExists(int id)
        {
            return _dal.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}