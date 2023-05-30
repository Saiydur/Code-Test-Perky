using Microsoft.AspNetCore.Mvc;

namespace CRUD.Web.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
