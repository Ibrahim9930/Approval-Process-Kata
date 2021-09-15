using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorWho.Tests
{
    public class InMemDbWebApplicationFactory<TStartup, TDbContext> : WebApplicationFactory<TStartup>
        where TStartup : class where TDbContext : DbContext
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var contextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(TDbContext)
                );
                services.Remove(contextDescriptor);


                services.AddScoped(_ =>
                {
                    var opt = new DbContextOptionsBuilder<TDbContext>();
                    opt.UseInMemoryDatabase("Testing Db");

                    return (TDbContext)Activator.CreateInstance(typeof(TDbContext), 
                        BindingFlags.CreateInstance |
                        BindingFlags.Public |
                        BindingFlags.Instance | 
                        BindingFlags.OptionalParamBinding,null, new object[] {opt.Options },CultureInfo.CurrentCulture);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetService<TDbContext>();

                    db?.Database.EnsureCreated();
                }
            });

            base.ConfigureWebHost(builder);
        }
    }
}