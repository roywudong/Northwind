using Northwind.Domain;
using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface IEmployeeService : IBaseService<Employees, EmployeeViewModel, int>
  {
    IQueryable<EmployeeViewModel> Get(int CurrPage, int PageSize, out int iTotal);

    EmployeeViewModel Get(int SupplierID);
  }
}