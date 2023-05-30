using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all order items");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get order item {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Create order item");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Update order item {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete order item {id}");
        }
    }
}
