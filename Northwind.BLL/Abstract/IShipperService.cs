using Northwind.Domain;
using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface IShipperService : IBaseService<Shippers, ShippersViewModel, int>
  {
    IQueryable<ShippersViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    ShippersViewModel Get(int SupplierID);
  }
}