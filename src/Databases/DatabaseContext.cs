using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Databases
{
    public class DatabaseContext : DbContext
    {
     public DbSet<Product> Products { get; set; }
     private IConfiguration _config;

    public DatabaseContext(IConfiguration config)
    {
        _config = config;
        //  public List<Order> Orders { get; set; }
        // public DbSet<User> Users { get; set; }
        // public List<Product> Products { get; set; }
        // public List<OrderItem> OrderItems { get; set; }
        // public List<Category> categories;
        // private IConfiguration _config;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@$"Host={_config[":Host"]};Username={_config["Db:Username"]};Password={_config["Db:Password"]};Database={_config["Db:Database"]}")
                        .UseSnakeCaseNamingConvention();
    }
    }
