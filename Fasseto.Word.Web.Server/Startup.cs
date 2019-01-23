using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace Fasseto.Word.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            IoC.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add SendGrid email sender
            services.AddSendGridEmailSender();

            //Add Template Email Sender
            services.AddEmailTemplateSender();
         
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Add ApplicationDBContext to a dependency injection
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(IoC.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Add Identity, Adds cookie based authentication
            //Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc...
            //NOTE: Automatically adds the validated user to the Identity 
            services.AddIdentity<ApplicationUser, IdentityRole>()

                    //Adds UserStore and RoleStore from this context
                    .AddEntityFrameworkStores<ApplicationDBContext>()

                    //Adds a provider that generates unique keys and hashes for things
                    //forgot password links, phone number verification codes and so on...
                    .AddDefaultTokenProviders();

            //Add JWT Authentication for API clients
            services.AddAuthentication()
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = IoC.Configuration["Jwt:Issuer"],
                            ValidAudience = IoC.Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoC.Configuration["Jwt:SecretKey"]))
                        };
                    });

            //Change Password Policy
            services.Configure<IdentityOptions>(options =>
            {
                //Make really weak passwords possible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                //Make sure unique emails are
                options.User.RequireUniqueEmail = true;
            });

            //Alter application cookie info
            services.ConfigureApplicationCookie(options =>
            {
                //redirect user to login action
                options.LoginPath = "/login";

                // Change cookie timeout
                options.ExpireTimeSpan = TimeSpan.FromSeconds(1500);
            });


            //Adds authorization policy
            services.AddAuthorization(options =>
            {
                //Adds a Canadian Only Policy
                options.AddPolicy("CanadiansOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Country, "Canada");
                });

                //Add roles to Authorization Policy
                options.AddPolicy("SuperUser", configure =>
                {
                    configure.RequireRole(new string[] { "Admin", "Manager", "TechLead"});
                });
            });

            //Adds MVC Framework Compatible with .NET Core 2.2 version
            services.AddMvc(options =>
            {
                //Add XML Formatters for input and output streams
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //Pass the IServiceProvider reference for use in the whole application
            IoC.Init(app.ApplicationServices);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //Setup Identity 
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
