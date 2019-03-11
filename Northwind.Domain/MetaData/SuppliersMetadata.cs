using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Domain.MetaData
{
  public class SuppliersMetadata
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SupplierID { get; set; }
  }
}

namespace Northwind.Domain
{
  [MetadataType(typeof(MetaData.SuppliersMetadata))]
  public partial class Suppliers
  {
  }
}