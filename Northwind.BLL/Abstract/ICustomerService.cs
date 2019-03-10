using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface ICustomerService
  {
    List<CustomerViewModel> Get();

    IQueryable<CustomerViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    CustomerViewModel Get(string CustomerID);

    void AddCustomer(CustomerViewModel models);

    void SaveCustomer(CustomerViewModel models);

    void Delete(string CustomerID);
  }
}