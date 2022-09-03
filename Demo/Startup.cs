using Demo.BL.Interface;
using Demo.BL.Mapper;
using Demo.BL.Repository;
using Demo.DAL.Database;
using Demo.Language;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
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
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
            })
                
                .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            services.AddDbContextPool<DemoContext>(opts =>
           opts.UseSqlServer(Configuration.GetConnectionString("DemoContext")));

            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            // Transient (One Instance For Every Operation)
            services.AddTransient<IDepartmentRep, DapartmentRep>();
            services.AddTransient<IEmployeeRep, EmployeeRep>();
            services.AddTransient<ICountryRep, CountryRep>();
            services.AddTransient<ICityRep, CityRep>();
            services.AddTransient<IDistrictRep, DistrictRep>();
            //«‰« ÂÕ «ÃÊ ⁄‰ ÿ—Ìﬁ  instance Â‰« «·„›—Ê÷ «‰ »«Œœ «Ï 
            //«‰Ï «ﬂ » «·ﬂ·«” Ê«·«‰ —ﬁÌ” » «⁄Ê Â‰«
            //» «⁄ «·ﬂ·«” «·Ï „Õ «Ã  constructor Ê»⁄œÂ« »⁄—› «Ê»ÃÌﬂ  »«·«‰ —›Ì” ⁄‰ ÿ—Ìﬁ «·
            //»’ ⁄·ÌÂ DepartmentControllerÌ«Œœ «Ê»ÃÌﬂ  „‰ «·«‰ —›Ì” œ« “Ì ⁄‰œÏ Â‰« «·

            // Scoped (One Intance For Each User For All Operations)
            //services.AddScoped<IDepartmentRep, DapartmentRep>();
            //services.AddScoped<IEmployeeRep, EmployeeRep>();

            // SingleTone  (One Instance For All Users)
            //services.AddSingleton<IDepartmentRep, DepartmentRep>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] {
                      new CultureInfo("ar-EG"),
                      new CultureInfo("en-US"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
