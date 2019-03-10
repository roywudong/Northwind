using AutoMapper;
using Northwind.Domain;
using Northwind.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.App_Start
{
  public class AutoMapperConfig
  {
    public static void Initialize()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Customers, CustomerViewModel>();
        cfg.CreateMap<CustomerViewModel, Customers>();

        cfg.CreateMap<Suppliers, SupplierViewModel>();
        cfg.CreateMap<SupplierViewModel, Suppliers>();

        cfg.CreateMap<Orders, OrderViewModel>();
        cfg.CreateMap<OrderViewModel, Orders>();
      });
    }
  }
}