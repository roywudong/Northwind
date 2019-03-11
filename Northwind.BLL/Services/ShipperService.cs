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
  public class ShipperService : BaseService<Shippers, ShippersViewModel, int>, IShipperService
  {
    public IQueryable<ShippersViewModel> Get(int CurrPage, int PageSize, out int iTotal)
    {
      iTotal = db.Get().Count();
      var shippers = db.Get()
        .OrderBy(c => c.ShipperID)
        .Skip((CurrPage - 1) * PageSize)
        .Take(PageSize);
      return Mapper.Map<IEnumerable<Shippers>, List<ShippersViewModel>>(shippers).AsQueryable();
    }

    public ShippersViewModel Get(int OrderID)
    {
      var order = db.Get().Where(c => c.ShipperID == OrderID).FirstOrDefault();
      return Mapper.Map<Shippers, ShippersViewModel>(order);
    }
  }
}