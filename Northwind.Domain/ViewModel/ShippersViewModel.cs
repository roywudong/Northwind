using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.ViewModel
{
  public class ShippersViewModel
  {
    public int ShipperID { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Orders> Orders { get; set; }
  }
}