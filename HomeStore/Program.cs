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
app.MapControllerRoute(
    "pagin",
    "page{page}",
    new { Controller = "Home", action = "Index" }
    );
app.MapDefaultControllerRoute();
ProductSeedData.AddTestData(app);
app.Run();
