using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ModeloNet6.Data;
using ModeloNet6.Events;
using ModeloNet6.Helpers;
using System.Configuration;

namespace ModeloNet6
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
            var stringConexao = Configuration.GetConnectionString("ApplicationDbContext");
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao)));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/login"; // 401
                    options.AccessDeniedPath = "/login/erro"; // 403 
                    //options.AccessDeniedPath = "/login/"; // 403 
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);// FromHours(1);
                    options.Cookie.Name = "ToDo.User";
                    options.EventsType = typeof(UserCookieAuthenticationEvents);
                    
                });

            services.AddScoped<UserCookieAuthenticationEvents>();
            services.AddScoped<AuthSaltHash>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
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
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}