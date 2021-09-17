using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderForm.Models;

namespace OrderForm.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MvcOrderContext _context;

        public OrdersController(MvcOrderContext context)
        {
            _context = context;
        }
        
        public IActionResult OrderList()
        {
            return View(_context.Orders.ToList());
        }

        public IActionResult OrderForm()
        {
            return View("OrderForm");
        }

        [HttpPost]
        public async Task<IActionResult> OrderForm(Order order)
        {
            if (order.Date < DateTime.Now)
                ModelState.AddModelError("Date", "Некорректная дата забора груза");
            if (ModelState.IsValid)
            {
                do
                {
                    order.OrderId = Guid.NewGuid();
                } while (await _context.Orders.AnyAsync(o => o.OrderId == order.OrderId));

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("OrderList");
            }
            return View("OrderForm", order);

        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("OrderList");
        }
    }
}