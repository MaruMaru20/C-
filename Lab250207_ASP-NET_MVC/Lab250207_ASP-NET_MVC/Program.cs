using System;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//¸ó­¶­±´ú¸Õ(³Ì²×)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//

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

app.UseSession();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Route}/{action=index}/{id?}/{context?}");
//app.MapControllerRoute(
//                name: "MouseA",
//                pattern: "{controller=Route}/{action=Mouse}/{id?}"
//                );


//app.MapControllerRoute(
//    name: "MouseB",
//    pattern: "{controller=Route}/{action=Mouse}/{apple?}/{bee?}"
//    );
//app.MapControllerRoute(
//    name: "prod",
//    pattern: "{Action = prod}/{id?}",
//    defaults: new { controller = "Route" }
////    controller = prod
////id = DCAY5I - A900BGV95
//);
//app.MapControllerRoute(
//    name: "Rabbit",
//    pattern: "{id?}",
//    defaults: new { controller = "Route", action = "Rabbit" }
//);

//app.MapControllerRoute(
//    name: "Rabbit",
//    pattern: "{id?}",
//    defaults: new { controller = "Route", action = "Rabbit" },
//    constraints: new { id = "^09\\d{8}$" }
//);
//^09\d{8}$

//app.MapControllerRoute(
//    name: "TestView",
//    pattern: "{controller=TestView}/{action=index}"


//);

app.MapControllerRoute(
    name: "JSON",
    pattern: "{controller=JSON}/{action=Index}"


);

app.Run();
