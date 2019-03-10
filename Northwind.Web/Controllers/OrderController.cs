using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BLL.Abstract;
using Northwind.BLL.Services;
using Northwind.Domain.ViewModel;
using Northwind.Web.Models;

namespace Northwind.Web.Controllers
{
  public class OrderController : Controller
  {
    private IOrderService orderService;

    public OrderController(IOrderService orderservice)
    {
      orderService = orderservice;
    }

    public ActionResult Index(string CustomerID)
    {
      var data = orderService.GetByCustomerID(CustomerID);

      if (data.Count() > 0)
      {
        return View(data);
      }
      else
      {
        TempData.Add("Message", $"{CustomerID} 目前沒有訂單");
        return RedirectToAction("Index", "Customer");
      }
    }

    public ActionResult Edit(int orderid)
    {
      var data = orderService.Get(orderid);
      return View(data);
    }
  }
}