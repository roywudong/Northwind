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
  public class CustomerService : ICustomerService
  {
    private IRepository<Customers> db;

    public CustomerService()
    {
      db = new GenericRepository<Customers>();
    }

    public List<CustomerViewModel> Get()
    {
      var listCostomer = db.Get().ToList();
      return Mapper.Map<List<Customers>, List<CustomerViewModel>>(listCostomer);
    }

    public IQueryable<CustomerViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var listCostomer = db.Get()
        .OrderBy(c => c.CustomerID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize).ToList();
      return Mapper.Map<List<Customers>, List<CustomerViewModel>>(listCostomer).AsQueryable();
    }

    public CustomerViewModel Get(string CustomerID)
    {
      var costomer = db.Get().Where(c => c.CustomerID == CustomerID).FirstOrDefault();
      return Mapper.Map<Customers, CustomerViewModel>(costomer);
    }

    public void AddCustomer(CustomerViewModel models)
    {
      var cust = Mapper.Map<CustomerViewModel, Customers>(models);
      db.Insert(cust);
    }

    public void SaveCustomer(CustomerViewModel models)
    {
      var cust = Mapper.Map<CustomerViewModel, Customers>(models);
      db.Update(cust);
    }

    public void Delete(string CustomerID)
    {
      var Customer = db.GetByID(CustomerID);
      db.Delete(Customer);
    }
  }
}