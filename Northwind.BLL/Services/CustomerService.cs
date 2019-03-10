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
  public class CustomerService : BaseService<Customers, CustomerViewModel, string>
    , ICustomerService
  {
    public IQueryable<CustomerViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var costomers = db.Get()
        .OrderBy(c => c.CustomerID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize);
      return Mapper.Map<IEnumerable<Customers>, List<CustomerViewModel>>(costomers).AsQueryable();
    }

    public CustomerViewModel Get(string CustomerID)
    {
      var costomer = db.Get().Where(c => c.CustomerID == CustomerID).FirstOrDefault();
      return Mapper.Map<Customers, CustomerViewModel>(costomer);
    }
  }
}