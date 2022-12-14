using BookShop.BLL.Contracts;
using BookShop.BLL.Services;
using BookShop.DAL.Context;
using BookShop.DAL.Interfaces;
using BookShop.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShopSystem.web {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddControllersWithViews();

      // Add DbContext using SQL Server Provider

      services.AddDbContext<BookShopContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BookShopConnection")));

      // General Dependency Injection

      services.AddScoped<IAuthorRepository, AuthorRepository>();
      services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

      // Repository Dependency Injection

      services.AddScoped<IAuthorRepository, AuthorRepository>();

      // Service Dependency Injection
      services.AddScoped<IAuthorService, AuthorService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
