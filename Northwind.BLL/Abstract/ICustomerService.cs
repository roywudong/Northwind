using Northwind.Domain;
using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface ICustomerService : IBaseService<Customers, CustomerViewModel, string>
  {
    IQueryable<CustomerViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    CustomerViewModel Get(string CustomerID);
  }
}