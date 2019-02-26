using ERP.EntityFramework;
using ERP.Services;
using ERP.Services.Interface;
using ERP.Services.MeanStack;
using ERP.WebApi.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Swashbuckle.AspNetCore.Swagger;

namespace ERP.WebApi
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
            // PROD
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    System.Web.HttpUtility.UrlDecode(Configuration["ConnectionString"])));

            // LOCAL
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"),
            //x =>
            //    x.MigrationsAssembly("ERP.Migrations")));

            services.AddIdentity<ERPUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc(options =>
            {
                options.InputFormatters.Insert(0, new VcardInputFormatter());
                options.OutputFormatters.Insert(0, new VcardOutputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Muhammad Sohail",
                        Email = "mirza.sohail@hotmail.com",
                        Url = "https://www.learnwithsohail.com"
                    },
                    License = new License
                    {
                        Name = "Use MIT Licence",
                        Url = "https://example.com/license"
                    }
                });
            });

            services.AddScoped<ICustomLogger, CustomLogger>();
            services.AddScoped<IFabricService, FabricService>();
            services.AddScoped<IMillService, MillService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IPaperMillService, PaperMillService>();
            services.AddScoped<IActionButtonsService, ActionButtonsService>();
            services.AddScoped<IProductRateService, ProductRateService>();
            services.AddScoped<IConsignmentOrderService, ConsignmentOrderService>();
            services.AddScoped<IDailyStockService, DailyStockService>();

            services.AddScoped<ExpenseService>();
            services.AddScoped<CategoryService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
