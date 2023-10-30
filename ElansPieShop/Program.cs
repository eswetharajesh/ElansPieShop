using ElansPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>(); //added own service
builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddControllersWithViews();// bringing services that enable mvc in application

builder.Services.AddDbContext<ElansPieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ElansPieShopDbContextConnection"]);
}); //add dbcontext in extension

var app = builder.Build();

app.UseStaticFiles();   //middleware that uses the static files.

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
//let mvc handle incoming requests on controller(endpoint middleware)

app.Run();
