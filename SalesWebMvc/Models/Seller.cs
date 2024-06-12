using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models;

public class Seller
{
    public int SellerId { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    [Display(Name = "Name")]
    public string? SellerName { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Write an email.")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "Write a correct email.")]
    [Display(Name = "Email")]
    public string? EmailAddress { get; set; }

    [Required(ErrorMessage = "Write a phone number.")]
    [StringLength(25, ErrorMessage = "The maximum length is 25 characters.")]
    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    [Display(Name = "Address")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Write the postal code.")]
    [StringLength(10, MinimumLength = 8, ErrorMessage = "The {0} must have at least {1} characters and the maximum length is {2} characters.")]
    [Display(Name = "Postal code")]
    public string? PostalCode { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    [Display(Name = "City")]
    public string? City { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    [Display(Name = "District")]
    public string? District { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Display(Name = "Join Company on")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime JoinCompany { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
    [Display(Name = "Base Salary")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double BaseSalary { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

    public Seller() { }

    public Seller(int sellerId, string? sellerName, DateTime birthday, string? emailAddress, string? phoneNumber, string? address, string? postalCode, string? city, string? district, DateTime joinCompany, double baseSalary, Department? department)
    {
        SellerId = sellerId;
        SellerName = sellerName;
        Birthday = birthday;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        Address = address;
        PostalCode = postalCode;
        City = city;
        District = district;
        JoinCompany = joinCompany;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord sr) {  Sales.Add(sr); }

    public void RemoveSales(SalesRecord sr) { RemoveSales(sr); }

    public double TotalSales(DateTime inicial, DateTime final)
    {
        return Sales.Where(sr => sr.Date >= inicial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}
