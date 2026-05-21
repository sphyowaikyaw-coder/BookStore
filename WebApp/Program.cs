using Dependency;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-GB6LURR;Database=Book;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;")));

builder.Services.AddScoped<DAO.DAO.UserDAO, DAO.DAO.DAOImpl.UserDAOImpl>();
builder.Services.AddScoped<Service.Service.UserService, Service.Service.ServiceImpl.UserServiceImpl>();

builder.Services.AddScoped<DAO.DAO.BookDAO, DAO.DAO.DAOImpl.BookDAOImpl>();
builder.Services.AddScoped<Service.Service.BookService, Service.Service.ServiceImpl.BookServiceImpl>();
builder.Services.AddScoped<Service.Service.FileService, Service.Service.ServiceImpl.FileServiceImpl>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
