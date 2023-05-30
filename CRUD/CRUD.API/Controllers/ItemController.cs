using Autofac;
using CRUD.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ItemController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILifetimeScope scope, ILogger<ItemController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ItemModel> Get()
        {
            try
            {
                var model = _scope.Resolve<ItemModel>();
                return model.GetAllItems();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't Get Items");
                return null;
            }
        }

        [HttpGet("{id}")]
        public ItemModel Get(Guid id)
        {
            try
            {
                var model = _scope.Resolve<ItemModel>();
                return model.GetItem(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't Get Item");
                return null;
            }
        }

        [HttpPost]
        public IActionResult Post(ItemModel model)
        {
            try
            {
                model.ResolveDependecnies(_scope);
                model.CreateItem();

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Couldn't Create Item");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(ItemModel model)
        {
            try
            {
                model.ResolveDependecnies(_scope);
                model.UpdateItem();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Cannot Update");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<ItemModel>();
                model.DeleteItem(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot Delete");
                return BadRequest();
            }
        }
    }
}
