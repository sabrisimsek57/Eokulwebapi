using Eokulwebapi.Context;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.Ders;
using Eokulwebapi.Service.DersProgramý;
using Eokulwebapi.Service.Devamsýzlýk;
using Eokulwebapi.Service.ÝliþkisiKesilen;
using Eokulwebapi.Service.Not;
using Eokulwebapi.Service.Öðrenci;
using Eokulwebapi.Service.Öðretmen;
using Eokulwebapi.Service.ÖnKayýtÖðrenci;
using Eokulwebapi.Service.Sýnýf;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<OkulContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OkulContext>();

builder.Services.AddScoped<IÖnKayýtÖðrenciService, ÖnKayýtÖðrenciService>();
builder.Services.AddScoped<IÖðrenciService, ÖðrenciService>();
builder.Services.AddScoped<ISýnýfService, SýnýfService>();
builder.Services.AddScoped<IDersProgramýService, DersProgramýService>();
builder.Services.AddScoped<INotService, NotService>();
builder.Services.AddScoped<IDevamsýzlýkService, DevamsýzlýkService>();
builder.Services.AddScoped<IÝliþkisiKesilenService, ÝliþkisiKesilenService>();
builder.Services.AddScoped<IDersService, DersService>();
builder.Services.AddScoped<IÖðretmenService, ÖðretmenService>();




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giriþ yapýlmamýþsa yönlendirilecek sayfa
        options.LogoutPath = "/Login/Logout"; // Çýkýþ yapýldýktan sonra yönlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Cookie'nin geçerlilik süresi
        options.SlidingExpiration = false; // Cookie'nin geçerliliði süresinin uzatýlmasý
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication(); // Kimlik doðrulama middleware
app.UseAuthorization(); // Yetkilendirme middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



// Eriþim reddi yönlendirmesi
app.MapControllerRoute(
    name: "accessdenied",
    pattern: "Account/AccessDenied",
    defaults: new { controller = "yetkisiz", action = "Index" });


app.Run();
