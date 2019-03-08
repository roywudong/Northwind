using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models
{
  public class PagingInfo
  {
    public int CurrentPage { get; set; }

    public int? CurrentCategory { get; set; }

    public int TotalPageCount { get; set; }

    public string BaseUrl { get; set; }
  }
}