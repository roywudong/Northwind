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

  [MetadataType(typeof(SuppliersMetadata))]
  public partial class Suppliers
  {
  }
}