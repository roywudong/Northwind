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
    private ICustomerService customerService;
    private IEmployeeService employeeService;

    public OrderController(IOrderService orderservice,
      ICustomerService customerservice,
      IEmployeeService employeeservice)
    {
      orderService = orderservice;
      customerService = customerservice;
      employeeService = employeeservice;
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
      ViewBag.CustomerID = new SelectList(customerService.Get(), "CustomerID", "CompanyName", data.CustomerID);
      ViewBag.EmployeeID = new SelectList(employeeService.Get(), "EmployeeID", "FullName", data.EmployeeID);

      return View(data);
    }

    [HttpPost]
    public ActionResult Edit(OrderViewModel order,
      [Bind(Include = "CustomerID")] CustomerViewModel customer,
      [Bind(Include = "EmployeeID")] EmployeeViewModel employee)
    {
      ViewBag.CustomerID = new SelectList(customerService.Get(), "CustomerID", "CompanyName", customer.CustomerID);
      ViewBag.EmployeeID = new SelectList(employeeService.Get(), "EmployeeID", "FullName", employee.EmployeeID);

      try
      {
        order.CustomerID = customer.CustomerID;
        order.EmployeeID = employee.EmployeeID;
        orderService.Save(order);
        return RedirectToAction("Index", "Order", new { CustomerID = order.CustomerID });
      }
      catch (Exception ex)
      {
        TempData.Add("Message", $"There has been some problems {ex.Message}");
        return RedirectToAction("Edit", "Order", new { OrderID = order.OrderID });
      }
    }

    public ActionResult Delete(int orderid, string customerid)
    {
      try
      {
        orderService.Delete(orderid);
        TempData.Add("Message", $"{orderid} has been delete");
        return RedirectToAction("Index", new { CustomerID = customerid });
      }
      catch
      {
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
    }

    public ActionResult Details(int orderid)
    {
      var data = orderService.Get(orderid);
      return View(data);
    }

    public ActionResult Create(string CustomerID)
    {
      ViewBag.EmployeeID = new SelectList(employeeService.Get(), "EmployeeID", "FullName");
      OrderViewModel order = new OrderViewModel();
      order.CustomerID = CustomerID;
      return View(order);
    }

    [HttpPost]
    public ActionResult Create(OrderViewModel order,
      [Bind(Include = "EmployeeID")] EmployeeViewModel employee)
    {
      ViewBag.CustomerID = new SelectList(customerService.Get(), "CustomerID", "CompanyName");
      ViewBag.EmployeeID = new SelectList(employeeService.Get(), "EmployeeID", "FullName");

      try
      {
        order.CustomerID = order.CustomerID;
        order.EmployeeID = employee.EmployeeID;
        orderService.Add(order);
        return RedirectToAction("Index", "Order", new { CustomerID = order.CustomerID });
      }
      catch (Exception ex)
      {
        TempData.Add("Message", $"There has been some problems {ex.Message}");
        return View();
      }
    }
  }
}