using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Context;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class DepartmentService
{
    private readonly AppDbContext _context;

    public DepartmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Departments.OrderBy(d => d.Name).ToListAsync();
    }

    //public async Task<List<Department>> FindAllAsync()
    //{
    //    // Retorna uma lista de departamentos simulada
    //    // Certifique-se de substituir isso pela lógica real de obtenção dos departamentos
    //    return new List<Department>
    //    {
    //        new Department { DepartmentId = 1, Name = "Sales" },
    //        new Department { DepartmentId = 2, Name = "Marketing" }
    //    };
    //}

}
