using Northwind.Domain;
using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface ISupplierService : IBaseService<Suppliers, SupplierViewModel, int>
  {
    IQueryable<SupplierViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    SupplierViewModel Get(int SupplierID);
  }
}