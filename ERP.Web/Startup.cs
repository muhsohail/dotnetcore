using System;
using ERP.EntityFramework;
using ERP.Filters;
using ERP.Services;
using ERP.Services.Interface;
using ERP.Services.MeanStack;
using ERP.WebApi.Formatters;
using ERP.WebApi.Handlers;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models;

namespace ERP
{
    public class Startup
    {
        ILogger _logger;
       // ICustomLogger _customLogger;

        public Startup(ILoggerFactory loggerFactory, IConfiguration configuration )
        {
            _logger = loggerFactory.CreateLogger<GlobalFiltersLogger>();
            //_logger = loggerFactory.CreateLogger<CustomLogger>();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // PROD
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    System.Web.HttpUtility.UrlDecode(Configuration["ConnectionString"])));

            // LOCAL
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("ERP.Migrations")));


            services.AddIdentity<ERPUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddNToastNotifyNoty();

            services.AddMvc(options =>
            {
                options.Filters.Add(new Tracking(_logger));
                options.InputFormatters.Insert(0, new VcardInputFormatter());
                options.OutputFormatters.Insert(0, new VcardOutputFormatter());
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

            services.AddTransient<ValidateHeaderHandler>();
            services.AddHttpClient("ERPClient", client =>
            {
                client.BaseAddress = new Uri(Configuration["hostUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "ERP");
                client.DefaultRequestHeaders.Add("Handshake", "Handshaking");
            }).AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<ERPClientService>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<ConsginmentERPClient>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<MillERPClient>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<FabricERPClient>().AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddScoped<ExpenseService>();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseNToastNotify();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
