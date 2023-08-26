using Microsoft.EntityFrameworkCore;
using BangazonBE.Models;

public class BangazonBEDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    //public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    //public DbSet<UserPayment> UserPayments { get; set; }
    public DbSet<Category> Categories { get; set; }


    public BangazonBEDbContext(DbContextOptions<BangazonBEDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {

        });
        modelBuilder.Entity<Product>().HasData(new Product[]
        {

        });
        modelBuilder.Entity<Order>().HasData(new Order[]
        {

        });
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {

        });
        modelBuilder.Entity<Category>().HasData(new Category[]
        {

        });
    }
}
