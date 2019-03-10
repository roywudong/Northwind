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
  public class SupplierController : Controller
  {
    private ISupplierService _service;

    public SupplierController(ISupplierService service)
    {
      _service = service;
    }

    public ActionResult Index(int currPage = 1)
    {
      int pageSize = 5, iTotal = 0;
      var data = _service.Get(currPage, pageSize, out iTotal).ToList();
      return View(new ListViewModel<SupplierViewModel>()
      {
        viewModel = data,
        PagingInfo = new PagingInfo
        {
          CurrentPage = currPage,
          CurrentCategory = null,
          TotalPageCount = (int)Math.Ceiling((decimal)iTotal / pageSize),
          BaseUrl = String.Format("/Supplier/Index/?currPage=")
        }
      });
    }

    public ActionResult Edit(int SupplierID)
    {
      var data = _service.Get(SupplierID);
      return View(data);
    }

    [HttpPost]
    public ActionResult Edit(SupplierViewModel supplier)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _service.Save(supplier);
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
    public ActionResult Create(SupplierViewModel supplier)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _service.Add(supplier);
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

    public ActionResult Delete(int SupplierID)
    {
      try
      {
        _service.Delete(SupplierID);
        TempData.Add("Message", $"{SupplierID} has been delete");
        return RedirectToAction("Index");
      }
      catch
      {
        TempData.Add("Message", $"There has been some problems");
        return View();
      }
    }

    public ActionResult Details(int SupplierID)
    {
      var data = _service.Get(SupplierID);
      return View(data);
    }
  }
}