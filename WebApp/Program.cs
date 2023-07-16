using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Factories;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));
builder.Services.AddDbContext<ProductContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CheckboxOptionService>();
builder.Services.AddScoped<GridCollectionCardService>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
