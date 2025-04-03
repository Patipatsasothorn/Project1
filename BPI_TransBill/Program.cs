using APInv.Models;
using BPI_TransBill.Models;
using BPI_TransBill.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BpiLiveContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpiLiveConnection")));
builder.Services.AddDbContext<BpiTrpaymentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpiTRConnection")));
builder.Services.AddDbContext<BpigContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpigConnection")));
builder.Services.AddDbContext<BpiUat2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UAT2Connection")));
builder.Services.AddDbContext<APInvtableContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpigConnection")));
builder.Services.AddDbContext<allcarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpigConnection")));
builder.Services.AddDbContext<OildebtContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpiTRConnection")));
builder.Services.AddDbContext<dmgebtContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpiTRConnection")));
builder.Services.AddDbContext<companycarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BpiTRConnection")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24); // ✅ ตั้ง session 24 ชม.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
