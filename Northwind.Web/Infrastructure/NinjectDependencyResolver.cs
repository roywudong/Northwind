using Ninject;
using Northwind.BLL.Abstract;
using Northwind.BLL.Services;
using Northwind.Web.Infrastructure.Abstract;
using Northwind.Web.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Infrastructure
{
  public class NinjectDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;

    public NinjectDependencyResolver(IKernel kernelParam)
    {
      kernel = kernelParam;
      AddBindings();
    }

    public object GetService(Type serviceType)
    {
      return kernel.TryGet(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return kernel.GetAll(serviceType);
    }

    private void AddBindings()
    {
      kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
      kernel.Bind<ICustomerService>().To<CustomerService>();
      kernel.Bind<ISupplierService>().To<SupplierService>();
      kernel.Bind<IOrderService>().To<OrderService>();
      kernel.Bind<IEmployeeService>().To<EmployeeService>();
      kernel.Bind<IShipperService>().To<ShipperService>();
    }
  }
}