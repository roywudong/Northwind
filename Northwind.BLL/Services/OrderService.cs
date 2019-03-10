using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Domain;
using Northwind.DAL.Interfaces;
using Northwind.DAL.Repository;
using Northwind.Domain.ViewModel;
using AutoMapper;
using Northwind.BLL.Abstract;

namespace Northwind.BLL.Services
{
  public class OrderService : BaseService<Orders, OrderViewModel, int>, IOrderService
  {
    public IQueryable<OrderViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var orders = db.Get()
        .OrderBy(c => c.OrderID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize);
      return Mapper.Map<IEnumerable<Orders>, List<OrderViewModel>>(orders).AsQueryable();
    }

    public OrderViewModel Get(int OrderID)
    {
      var order = db.Get().Where(c => c.OrderID == OrderID).FirstOrDefault();
      return Mapper.Map<Orders, OrderViewModel>(order);
    }

    public IQueryable<OrderViewModel> GetByCustomerID(string CustomerID)
    {
      var orders = db.Get().Where(c => c.Customers.CustomerID == CustomerID);
      return Mapper.Map<IEnumerable<Orders>, List<OrderViewModel>>(orders).AsQueryable();
    }
  }
}