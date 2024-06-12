using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models;

public class Department
{
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    public Department()
    {
    }

    public Department(int id, string name)
    {
        DepartmentId = id;
        Name = name;
    }

    public void AddSeller(Seller seller)
    {
        Sellers.Add(seller);
    }

    public double TotalSales(DateTime initial, DateTime final)
    {
        return Sellers.Sum(seller => seller.TotalSales(initial, final));
    }
}
