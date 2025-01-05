using Microsoft.EntityFrameworkCore;

namespace Bageriapi.Data;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
}

