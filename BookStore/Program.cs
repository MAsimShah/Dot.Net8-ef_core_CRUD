using DAL.AppDbContext;
using DAL.Interfaces;
using DAL.Repositories;
using DomainEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// add razor runtime compilation
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;

// configure identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // configure identity options here
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<BookStoreContext>().AddDefaultTokenProviders();

// set connection with db
// specify the assembly containing the migrations for a given BookStoreContext
builder.Services.AddDbContext<BookStoreContext>(dbOptions => dbOptions.UseSqlServer(builder.Configuration["DefaultConnection:ConnectionString"], sqlDBOptions => sqlDBOptions.MigrationsAssembly("DAL")));

// services register
builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddTransient<IBookServices, BookServices>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// add middleware Authenticate and Authorize
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
