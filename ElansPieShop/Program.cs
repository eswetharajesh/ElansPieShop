using ElansPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //added own service
builder.Services.AddScoped<IPieRepository, PieRepository>();

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

app.MapDefaultControllerRoute();//default controller  "{controller=Home}/{action=Index}/{id?}"
//middleware component that points to the actual action on the controller
//let mvc handle incoming requests on controller(endpoint middleware)

DbInitializer.Seed(app); // to call appbuilder in DbIntitializer

app.Run();
