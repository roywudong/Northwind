using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Domain.MetaData
{
  public class EmployeeMetadata
  {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeID { get; set; }
  }
}

namespace Northwind.Domain
{
  [MetadataType(typeof(MetaData.EmployeeMetadata))]
  public partial class Employees
  {
    public string FullName { get { return $"{FirstName} {LastName} "; } }
  }
}