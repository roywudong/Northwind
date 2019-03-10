using System;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Domain;
using Northwind.Domain.ViewModel;
using Northwind.BLL.Services;
using Northwind.BLL.Abstract;

namespace Test.BLL
{
  [TestClass]
  public class Order
  {
    public Order()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Orders, OrderViewModel>();
        cfg.CreateMap<OrderViewModel, Orders>();
      });
    }

    [TestMethod]
    public void GetOrdersByCustomerID()
    {
      IOrderService orderService = new OrderService();
      int count = orderService.GetByCustomerID("ALFKI").Count();
      Assert.AreEqual(count, 6);
    }
  }
}