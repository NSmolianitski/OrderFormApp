using Microsoft.AspNetCore.Mvc;
using OrderForm.Models;

namespace OrderForm.Controllers
{
    public class OrderController : Controller
    {
        private MvcOrderContext _db;

        public OrderController(MvcOrderContext context)
        {
            _db = context;
        }

        public IActionResult OrderForm()
        {
            return View();
        }

        public IActionResult OrderList(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello, " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}