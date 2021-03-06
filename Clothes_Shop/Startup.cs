using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Clothes_Shop.Services;

namespace Clothes_Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options => {
                options.AddPolicy("readonlypolicy",
                    builder => builder.RequireRole("Admin", "Manager", "User"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("Admin", "Manager"));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

      

            services.AddDbContext<CategoriesContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));              
            });

            services.AddDbContext<CommentsContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));              
            });

            services.AddDbContext<FeaturesContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<GendersContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<ItemsContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<CartContext>(options =>
            {
                options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ItemsService>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IGendersRepository, GendersRepository>();
            services.AddScoped<IFeaturesRepository, FeaturesRepository>();
            services.AddScoped<ICartsRepository, CartsRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession();
     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
