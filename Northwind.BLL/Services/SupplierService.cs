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
  public class SupplierService : BaseService<Suppliers, SupplierViewModel, int>, ISupplierService
  {
    public IQueryable<SupplierViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var suppliers = db.Get()
        .OrderBy(c => c.SupplierID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize);
      return Mapper.Map<IEnumerable<Suppliers>, List<SupplierViewModel>>(suppliers).AsQueryable();
    }

    public SupplierViewModel Get(int SupplierID)
    {
      var supplier = db.Get().Where(c => c.SupplierID == SupplierID).FirstOrDefault();
      return Mapper.Map<Suppliers, SupplierViewModel>(supplier);
    }
  }
}