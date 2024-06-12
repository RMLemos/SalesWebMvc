using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Context;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services;

public class SellerService
{
    private readonly AppDbContext _context;

    public SellerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Seller>> FindAllAsync()
    {
        return await _context.Sellers.ToListAsync();
    }

    public async Task InsertAsync(Seller obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id)
    {
        return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.SellerId == id);
    }

    public async Task RemoveAsync(int id)
    {
        try
        {
            var obj = await _context.Sellers.FindAsync(id);
            if (obj != null)
            {
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbUpdateException e)
        {
            throw new IntegrityException(e.Message);
        }
        
    }

    public async Task UpdateAsync(Seller obj)
    {
        if (! await _context.Sellers.AnyAsync(x => x.SellerId == obj.SellerId))
        {
            throw new NotFoundException("Seller Not Found");
        }
        try
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbUpdateConcurrencyException(e.Message);
        }
    }
}
