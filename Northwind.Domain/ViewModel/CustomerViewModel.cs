using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.ViewModel
{
  public class CustomerViewModel
  {
    [Required]
    [Display(Name = "客戶ID")]
    public string CustomerID { get; set; }

    [Display(Name = "公司名稱")]
    [Required(ErrorMessage = "請輸入客戶公司名稱")]
    public string CompanyName { get; set; }

    [Display(Name = "聯絡人姓名")]
    public string ContactName { get; set; }

    [Display(Name = "聯絡人職稱")]
    public string ContactTitle { get; set; }

    [Display(Name = "地址")]
    public string Address { get; set; }

    [Display(Name = "城市")]
    public string City { get; set; }

    [Display(Name = "區域")]
    public string Region { get; set; }

    [Display(Name = "郵遞區號")]
    public string PostalCode { get; set; }

    [Display(Name = "國家")]
    public string Country { get; set; }

    [Display(Name = "電話")]
    public string Phone { get; set; }

    [Display(Name = "傳真")]
    public string Fax { get; set; }
  }
}