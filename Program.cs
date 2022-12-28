using information.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
    string ConnectionString = "workstation id=myInformation2022.mssql.somee.com;packet size=4096;user id=muaz_asiri_SQLLogin_1;pwd=yuz9ss9u8c;data source=myInformation2022.mssql.somee.com;persist security info=False;initial catalog=myInformation2022";
try
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<MyDB>(options => options.UseSqlServer(ConnectionString));
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    // builder.Services.AddControllers();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    // builder.Services.AddEndpointsApiExplorer();


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{

    
    DbContextOptions<MyDB> dbOptions=new DbContextOptions<MyDB>();
    
    var dbbuilder = new DbContextOptionsBuilder(dbOptions);
    dbbuilder.UseSqlServer(ConnectionString);

    var db = new MyDB(dbbuilder.UseSqlServer(ConnectionString).Options);
    Reg.CreateErr("Program", db, ex).Result;
}