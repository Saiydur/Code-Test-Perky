﻿using Microsoft.AspNetCore.Mvc;

namespace CRUD.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
