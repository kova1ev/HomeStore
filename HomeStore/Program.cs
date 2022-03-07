using Microsoft.EntityFrameworkCore;
using HomeStore.Data;
using HomeStore.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
string connectionstring = builder.Configuration.GetConnectionString("Default");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMvc();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionstring));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("IdentityDb")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
// app.MapControllerRoute("category",
//                         "{category}",
//                         new { Controller = "Home", action = "Index", page = 1 });

// app.MapControllerRoute("catpage",
//                         "{category}/Page{page:int}",
//                         new { Controller = "Home", action = "Index" });

// app.MapControllerRoute("page",
//                         "Page{page:int}",
//                         new { Controller = "Home", action = "Index", page = 1 });

// app.MapControllerRoute("pagination",
//                         "Products/Page{page}",
//                         new { Controller = "Home", action = "Index", page = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

ProductSeedData.AddTestData(app);
IdentitySeedData.EnsurePopulated(app);
app.Run();
