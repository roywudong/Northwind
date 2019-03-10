using System;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.BLL.Abstract;
using Northwind.BLL.Services;
using Northwind.Domain;
using Northwind.Domain.ViewModel;

namespace Test.BLL
{
  [TestClass]
  public class Customer
  {
    public Customer()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Customers, CustomerViewModel>();
        cfg.CreateMap<CustomerViewModel, Customers>();
      });
    }

    [TestMethod]
    public void GetTest()
    {
      ICustomerService customerService = new CustomerService();
      var data = customerService.Get();
      Assert.AreEqual(data.Count, 91);
    }

    [TestMethod]
    public void GetPageTest()
    {
      ICustomerService customerService = new CustomerService();
      int total = 0;
      var data = customerService.Get(2, 10, out total).ToList();
      Assert.AreEqual(total, 91);
      string CompanyName = data[6].CompanyName;
      Assert.AreEqual(CompanyName, "Drachenblut Delikatessen");
    }
  }
}