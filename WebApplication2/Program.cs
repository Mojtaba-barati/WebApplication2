using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using webmarket.AccesData;
using webmarket.AccesData.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using webmarket.unity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<applicationDBcontext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("defultconnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<applicationDBcontext>();

builder.Services.AddScoped<iproductsservices,products>();

builder.Services.AddScoped<ipcategory,categoryserveis>();

builder.Services.AddScoped<ishopingcard, shopingcardservices>();

builder.Services.AddScoped<icompany,compony>();

builder.Services.AddScoped<IOrderHeaderService, OrderHeaderService>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Loginout" ;
    option.AccessDeniedPath = $"/Identity/Account/AccessDenied" ;
}
);


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

app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{Area=customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
