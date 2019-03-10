using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ViewModel
{
  public class OrderViewModel
  {
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public Nullable<int> EmployeeID { get; set; }
    public Nullable<System.DateTime> OrderDate { get; set; }
    public Nullable<System.DateTime> RequiredDate { get; set; }
    public Nullable<System.DateTime> ShippedDate { get; set; }
    public Nullable<int> ShipVia { get; set; }
    public Nullable<decimal> Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }

    public virtual Customers Customers { get; set; }
    public virtual Employees Employees { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Order_Details> Order_Details { get; set; }

    public virtual Shippers Shippers { get; set; }
  }
}