﻿using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Domain.ViewModel
{
  public class SupplierViewModel
  {
    public int SupplierID { get; set; }

    [Required(ErrorMessage = "請輸入供應商公司名稱")]
    public string CompanyName { get; set; }

    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string HomePage { get; set; }
  }
}