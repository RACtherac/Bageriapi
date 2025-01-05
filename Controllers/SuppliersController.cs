using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/Suppliers")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly BakeryContext _context;

    public SuppliersController(BakeryContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(int id)
    {
        var supplier = await _context.Suppliers
            .Include(s => s.SupplierProducts)
            .ThenInclude(sp => sp.Product)
            .Where(s => s.SupplierId == id)
            .Select(s => new
            {
                s.Name,
                Products = s.SupplierProducts.Select(sp => new
                {
                    sp.Product.Name,
                    sp.PricePerKg
                })
            })
            .FirstOrDefaultAsync(); 

        if (supplier == null)
        {
            return NotFound();
        }

        return Ok(supplier);
    }
}
