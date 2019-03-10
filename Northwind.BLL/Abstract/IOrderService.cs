using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Domain;
using Northwind.Domain.ViewModel;

namespace Northwind.BLL.Abstract
{
  public interface IOrderService : IBaseService<Orders, OrderViewModel, int>
  {
    IQueryable<OrderViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    OrderViewModel Get(int OrderID);

    IQueryable<OrderViewModel> GetByCustomerID(string CustomerID);
  }
}