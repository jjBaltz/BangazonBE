using Microsoft.EntityFrameworkCore;
using BangazonBE.Models;

public class BangazonBEDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<UserPayment> UserPayments { get; set; }
    public DbSet<Category> Categories { get; set; }


    public BangazonBEDbContext(DbContextOptions<BangazonBEDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { UserId = 101, FirstName = "Prianka", LastName = "Pavel", Email = "pavel@outlook.com", Address = "70 Studebaker Street", IsSeller = true},
            new User { UserId = 102, FirstName = "Abraham", LastName = "Keutzer", Email = "keutzer@gmail.com", Address = "7589 Courtland Ave", IsSeller = false},
            new User { UserId = 103, FirstName = "Honest", LastName = "Goods", Email = "honestgoods@me.com", Address = "485 Laurel St", IsSeller = true},
            new User { UserId = 104, FirstName = "Megan", LastName = "Leary", Email = "mleary@icloud.com", Address = "5698 Grove Lane", IsSeller = false},
            new User { UserId = 105, FirstName = "George", LastName = "Petersen", Email = "gpetersen@yahoo.com", Address = "10 South Harrison Dr", IsSeller = false}
        });
        modelBuilder.Entity<UserPayment>().HasData(new UserPayment[]
        {
            new UserPayment { UPId = 201, UserId = 101, PaymentId = 302},
            new UserPayment { UPId = 202, UserId = 102, PaymentId = 303},
            new UserPayment { UPId = 203, UserId = 103, PaymentId = 306},
            new UserPayment { UPId = 204, UserId = 104, PaymentId = 308},
            new UserPayment { UPId = 205, UserId = 105, PaymentId = 304}
        });
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
            new PaymentType { PaymentId = 301, CardTypeName = "Visa", CardNumber = 3526},
            new PaymentType { PaymentId = 302, CardTypeName = "Visa", CardNumber = 2391},
            new PaymentType { PaymentId = 303, CardTypeName = "Giftcard", CardNumber = 5364},
            new PaymentType { PaymentId = 304, CardTypeName = "Discover", CardNumber = 3518},
            new PaymentType { PaymentId = 305, CardTypeName = "Mastercard", CardNumber = 6952},
            new PaymentType { PaymentId = 306, CardTypeName = "American Express", CardNumber = 2986},
            new PaymentType { PaymentId = 307, CardTypeName = "Mastercard", CardNumber = 1628},
            new PaymentType { PaymentId = 308, CardTypeName = "American Express", CardNumber = 4352}
        });
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product { ProductId = 401, Name = "Nintendo Switch", UserId = 103, Description = "Classic original red and blue console in perfect untouched condition", ProductPrice = 300M, CategoryId = 2, Quantity = 3},
            new Product { ProductId = 402, Name = "MAC Consealer Shade 3", UserId = 101, Description = "MAC Beauty Concealer in shade 3 for ivory skin-tone", ProductPrice = 12.99M, CategoryId = 4, Quantity = 10},
            new Product { ProductId = 403, Name = "Def Leppard Vintage Tshirt", UserId = 101, Description = "1985 Vintage Def Leppard tee in worn-gray with front and back decal, one of a kind", ProductPrice = 24.99M, CategoryId = 5, Quantity = 1},
            new Product { ProductId = 404, Name = "Dining Chairs", UserId = 103, Description = "Four Mid-Century Modern Dining Chairs In Dark Walnut Finish", ProductPrice = 50M, CategoryId = 1, Quantity = 4},
            new Product { ProductId = 405, Name = "Pothos Propagations", UserId = 101, Description = "Golden Pothos rooted propogations in small planters. Need gone NOW", ProductPrice = 3.78M, CategoryId = 1, Quantity = 24}
        });
        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct { OPId = 501, ProductId = 403, OrderId = 601},
            new OrderProduct { OPId = 502, ProductId = 404, OrderId = 602},
            new OrderProduct { OPId = 503, ProductId = 401, OrderId = 603},
            new OrderProduct { OPId = 504, ProductId = 405, OrderId = 604},
            new OrderProduct { OPId = 505, ProductId = 402, OrderId = 605}
        });
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order { OrderId = 601, UserId = 102, CreatedAt = DateTime.Now, StatusId = 1},
            new Order { OrderId = 602, UserId = 102, CreatedAt = DateTime.Now, StatusId = 2},
            new Order { OrderId = 603, UserId = 104, CreatedAt = DateTime.Now, StatusId = 4},
            new Order { OrderId = 604, UserId = 104, CreatedAt = DateTime.Now, StatusId = 6},
            new Order { OrderId = 605, UserId = 105, CreatedAt = DateTime.Now, StatusId = 5}
        });
        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[]
        {
            new OrderStatus { StatusId = 1, Status = "Pending"},
            new OrderStatus { StatusId = 2, Status = "In Progress"},
            new OrderStatus { StatusId = 4, Status = "Completed"},
            new OrderStatus { StatusId = 5, Status = "Shipped"},
            new OrderStatus { StatusId = 6, Status = "Delivered"}
        });
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { CategoryId = 1, Type = "Home"},
            new Category { CategoryId = 2, Type = "Electronics"},
            new Category { CategoryId = 3, Type = "Grocery"},
            new Category { CategoryId = 4, Type = "Beauty"},
            new Category { CategoryId = 5, Type = "Clothing"}
        });
    }
}
