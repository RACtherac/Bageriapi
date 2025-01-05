using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/products")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly BakeryContext _context;

    public ProductController(BakeryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult>GetProducts()
    {
        var products = await _context.Products
        .Include(p => p.SupplierProducts)
        .ThenInclude(sp => sp.Supplier)
        .Select(p => new
        {
            p.Name,
            Suppliers = p.SupplierProducts.Select(sp => new
            {
                sp.Supplier.Name,
                sp.PricePerKg
            })
        })
        .ToListAsync();

        return Ok(products);
    }
    [HttpGet("{name}")]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var products = await _context.Products
        .Include(p => p.SupplierProducts)
        .ThenInclude(sp => sp.Supplier)
        .Select(p => new
        {
            p.Name,
            Suppliers = p.SupplierProducts.Select(sp => new
            {
                sp.Supplier.Name,
                sp.PricePerKg
            })
        })
        .ToListAsync();
        if (!products.Any())
        {
            return NotFound("Prudit hittas inte.");
        }

        return Ok(products);

    }
}