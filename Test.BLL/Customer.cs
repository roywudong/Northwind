using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.BLL.Services;

namespace Test.BLL
{
  [TestClass]
  public class Customer
  {
    [TestMethod]
    public void GetTest()
    {
      CustomerService customerService = new CustomerService();
      var data = customerService.Get();
      Assert.AreEqual(data.Count, 91);
    }

    [TestMethod]
    public void GetPageTest()
    {
      CustomerService customerService = new CustomerService();
      int total = 0;
      var data = customerService.Get(2, 10, out total).ToList();
      Assert.AreEqual(total, 91);
      string CompanyName = data[6].CompanyName;
      Assert.AreEqual(CompanyName, "Drachenblut Delikatessen");
    }
  }
}