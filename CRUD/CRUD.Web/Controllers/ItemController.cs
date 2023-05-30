using Microsoft.AspNetCore.Mvc;

namespace CRUD.Web.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
