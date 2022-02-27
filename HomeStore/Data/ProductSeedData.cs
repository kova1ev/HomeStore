using HomeStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace HomeStore.Data
{
    public static class ProductSeedData
    {
        internal static void AddTestData(IApplicationBuilder app)
        {
            AppDbContext dbcontext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbcontext.Database.GetPendingMigrations().Any())
            {
                dbcontext.Database.Migrate();
            }
            if (!dbcontext.Products.Any())
            {
                dbcontext.Products.AddRange(
                    new Product { Name = "Hobbit", Category = "Books", Description = "Tolkin", Price = 400m },
                    new Product { Name = "Learn C++", Category = "Books", Description = "Stroustrup", Price = 550m },
                    new Product { Name = "Red Cup", Category = "Cups", Description = "Cup for kids", Price = 120m },
                    new Product { Name = "Chess", Category = "Games", Description = "Regular Chess", Price = 240m },
                    new Product { Name = "Teddy Bear", Category = "Toys", Description = "white teddy bear", Price = 70m },
                    new Product { Name = "Mini Sport Car", Category = "Toys", Description = null, Price = 30m },
                    new Product { Name = "Learn C#", Category = "Books", Description = "Freeman", Price = 660m },
                    new Product { Name = "Kid's Gun", Category = "Toys", Description = "Light gun", Price = 400m }
                );
            }
            dbcontext.SaveChanges();
        }
    }
}