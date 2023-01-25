using Business.DTOs.Employee;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Core.Entities.Identity;
using DataAccess.Contexts;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using DataAccess.Validators.Employee;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//IWebHostEnvironment
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opts =>
{
	opts.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
builder.Services.AddIdentity<AppUser, IdentityRole>(opts =>
	{
		opts.Password.RequireNonAlphanumeric=true;
		opts.Password.RequiredLength = 6;
		opts.Password.RequireDigit=true;
		opts.Lockout.MaxFailedAccessAttempts = 5;
		opts.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromSeconds(60);

    }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);


app.MapControllerRoute(
   name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
	);

//app.MapGet("/", () => "Hello World!");

app.Run();
