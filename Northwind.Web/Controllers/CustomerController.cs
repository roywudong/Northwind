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
  [Authorize]
  public class CustomerController : Controller
  {
    private ICustomerService customerService;

    public CustomerController(ICustomerService customerservice)
    {
      customerService = customerservice;
    }

    public ActionResult Index(int currPage = 1)
    {
      int pageSize = 5, iTotal = 0;
      var data = customerService.Get(currPage, pageSize, out iTotal).ToList();
      return View(new ListViewModel<CustomerViewModel>()
      {
        viewModel = data,
        PagingInfo = new PagingInfo
        {
          CurrentPage = currPage,
          CurrentCategory = null,
          TotalPageCount = (int)Math.Ceiling((decimal)iTotal / pageSize),
          BaseUrl = String.Format("/Customer/Index/?currPage=")
        }
      });
    }

    public ActionResult Edit(string CustomerID)
    {
      var data = customerService.Get(CustomerID);
      return View(data);
    }

    [HttpPost]
    public ActionResult Edit(CustomerViewModel customer)
    {
      try
      {
        if (ModelState.IsValid)
        {
          customerService.Save(customer);
          TempData.Add("Message", "The customer was successfully added");
          return RedirectToAction("Index");
        }
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
      catch
      {
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(CustomerViewModel customer)
    {
      try
      {
        if (ModelState.IsValid)
        {
          customerService.Add(customer);
          TempData.Add("Message", "The customer was successfully added");
          return RedirectToAction("Index");
        }
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
      catch (Exception ex)
      {
        TempData.Add("Message", $"There has been some problems {ex.ToString()}");
        return View();
      }
    }

    public ActionResult Delete(string CustomerID)
    {
      try
      {
        customerService.Delete(CustomerID);
        TempData.Add("Message", $"{CustomerID} has been delete");
        return RedirectToAction("Index");
      }
      catch
      {
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
    }

    public ActionResult Details(string CustomerID)
    {
      var data = customerService.Get(CustomerID);
      return View(data);
    }
  }
}