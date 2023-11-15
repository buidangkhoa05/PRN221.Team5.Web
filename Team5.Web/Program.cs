using Autofac.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Team5.Web.Config;

namespace Team5.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Authen", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole(Role.Administrator.ToString());
                });
                options.AddPolicy("Staff", policy =>
                {
                    policy.RequireRole(Role.Administrator.ToString(),Role.Staff.ToString());
                });
                options.AddPolicy("Traineer", policy =>
                {
                    policy.RequireRole(Role.Administrator.ToString(), Role.Staff.ToString(), Role.ZooTrainer.ToString());
                });
            });

            builder.Services.AddRazorPages(options =>
            {
                //options.Conventions.AuthorizePage("/Index", "Authen");
                options.Conventions.AuthorizeFolder("/", "Authen");
                options.Conventions.AuthorizeFolder("/ManageAccount", "Admin");
                options.Conventions.AuthorizeFolder("/ManageAnimal", "Traineer");
                options.Conventions.AuthorizeFolder("/ManageAnimalSpec", "Traineer");
                options.Conventions.AuthorizeFolder("/ManageCage", "Traineer");
                options.Conventions.AuthorizeFolder("/ManageFood", "Traineer");
                options.Conventions.AuthorizeFolder("/ManageTraineerProfile", "Staff");
                options.Conventions.AuthorizeFolder("/ManageZooNews", "Staff");
                options.Conventions.AuthorizeFolder("/ManageZooSection", "Traineer");

                //options.Conventions.AuthorizeFolder("/ManageAnimal", "Authen");
            });

            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Life time of cookie
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {

                options.LoginPath = "/Auth";
                options.AccessDeniedPath = "/AccessDenie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
            });

            //builder.Services.AddDbContext();
            //builder.Services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            builder.Services.AddServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}