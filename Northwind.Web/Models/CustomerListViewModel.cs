using Northwind.Domain.ViewModel;
using Northwind.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models
{
  public class CustomerListViewModel
  {
    public List<CustomerViewModel> Customers { get; set; }
    public PagingInfo PagingInfo { get; set; }
  }
}