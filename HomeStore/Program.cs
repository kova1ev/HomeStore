using Microsoft.EntityFrameworkCore;
using HomeStore.Data;

var builder = WebApplication.CreateBuilder(args);
string connectionstring = builder.Configuration.GetConnectionString("Default");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMvc();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionstring));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute("catpage",
                        "{category}/Page{page:int}",
                        new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
                        "Page{page:int}",
                        new { Controller = "Home", action = "Index", pPage = 1 });

app.MapControllerRoute("category",
                        "{category}",
                        new { Controller = "Home", action = "Index", page = 1 });

app.MapControllerRoute("pagination",
                        "Products/Page{page}",
                        new { Controller = "Home", action = "Index", page = 1 });

app.MapDefaultControllerRoute();

ProductSeedData.AddTestData(app);

app.Run();
