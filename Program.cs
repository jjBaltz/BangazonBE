using BangazonBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonBEDbContext>(builder.Configuration["BangazonBEDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//PRODUCTS
app.MapGet("/api/products", (BangazonBEDbContext db) =>
{
    return db.Products.ToList();
});

app.MapGet("/api/products/{id}", (BangazonBEDbContext db, int id) =>
{
    return db.Products.Single(p => p.ProductId == id);
});

app.MapPost("/api/products", (BangazonBEDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/products/{product.ProductId}", product);
});

app.MapDelete("/api/products/{id}", (BangazonBEDbContext db, int id) =>
{
    Product product = db.Products.SingleOrDefault(product => product.ProductId == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    db.Products.Remove(product);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/api/products/{id}", (BangazonBEDbContext db, int id, Product product) =>
{
    Product productToUpdate = db.Products.SingleOrDefault(product => product.ProductId == id);
    if (productToUpdate == null)
    {
        return Results.NotFound();
    }
    productToUpdate.Name = product.Name;
    productToUpdate.Description = product.Description;
    productToUpdate.ProductPrice = product.ProductPrice;
    productToUpdate.Quantity = product.Quantity;
    productToUpdate.UserId = product.UserId;
    productToUpdate.CategoryId = product.CategoryId;

    db.SaveChanges();
    return Results.NoContent();
});

//ORDERS
app.MapGet("/api/orders", (BangazonBEDbContext db) =>
{
    return db.Orders
        .Include(o => o.OrderProduct)
        .ThenInclude(op => op.Product)
        .ToList();
});

app.MapGet("/api/orders/{id}", (BangazonBEDbContext db, int id) =>
{
    return db.Orders
        .Include(o => o.OrderProduct)
        .ThenInclude(op => op.Product)
        .Single(o => o.OrderId == id);
});

app.MapPost("/api/orders", (BangazonBEDbContext db, Order order) =>
{
    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Created($"/api/orders/{order.OrderId}", order);
});

app.MapDelete("/api/orders/{id}", (BangazonBEDbContext db, int id) =>
{
    Order order = db.Orders.SingleOrDefault(order => order.OrderId == id);
    if (order == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.NoContent();

});

//CATEGORIES
app.MapGet("/api/categories", (BangazonBEDbContext db) =>
{
    return db.Categories.ToList();
});

//USERS
app.MapGet("api/users/{id}/closed", (BangazonBEDbContext db, int id) =>
{

});

app.Run();

