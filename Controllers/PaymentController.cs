using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using braspag.Models;
using braspag.Util;

namespace braspag.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public async Task<IActionResult> OrderInfo(HomeForm form)
        {
            Console.WriteLine("awwww");
            string result = await BrasPagUtil.getOrder(form.paymentId);
            TempData["Data"] = result;
            TempData["ViewFrom"] = "Order";
            return RedirectToAction("Result");
        }

        [HttpPost, ActionName("Order")]
        public async Task<IActionResult> OrderPost(OrderViewModel order)
        {
            if (!ModelState.IsValid) return View(order);
            string result = await BrasPagUtil.newOrder(order);
            TempData["Data"] = result;
            TempData["ViewFrom"] = "Order";
            return RedirectToAction("Result");
        }

        public async Task<IActionResult> Cancel(string id)
        {
            string result = await BrasPagUtil.cancelOrder(id);
            TempData["Data"] = result;
            TempData["ViewFrom"] = "Cancel";
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
