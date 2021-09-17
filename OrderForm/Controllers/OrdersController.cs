using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> OrderForm(Order order)
        {
            if (order.Date < DateTime.Now)
                ModelState.AddModelError("Date", "Некорректная дата забора груза");
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
            }
            return View(order);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
    }
}