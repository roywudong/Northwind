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
  public class EmployeeService : BaseService<Employees, EmployeeViewModel, int>, IEmployeeService
  {
    public IQueryable<EmployeeViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var employees = db.Get()
        .OrderBy(c => c.EmployeeID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize);
      return Mapper.Map<IEnumerable<Employees>, List<EmployeeViewModel>>(employees).AsQueryable();
    }

    public EmployeeViewModel Get(int EmployeeID)
    {
      var employee = db.Get().Where(c => c.EmployeeID == EmployeeID).FirstOrDefault();
      return Mapper.Map<Employees, EmployeeViewModel>(employee);
    }
  }
}