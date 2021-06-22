using Common;
using CrossCutting;
using CrossCutting.Filters;
using CrossCutting.IoC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui
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
            services.AddControllersWithViews();
            //解析上下文,HttpContext.Current会围绕这个业务逻辑
            services.AddHttpContextAccessor();
            //用于配置 HstsOptions 的委托。
            services.AddHsts(options =>
            {
                options.Preload = true;//设置严格传输安全标头的预载参数。
                options.IncludeSubDomains = true;//启用严格传输-安全标头的 includeSubDomain 参数。
                options.MaxAge = TimeSpan.FromDays(60);//设置严格传输安全标头的最大生存期参数。
                options.ExcludedHosts.Add("");//不会添加 HSTS 标头的主机名列表
            });
            services.AddSameSiteCookiePolicy();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();//分布式内存缓存
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000 * 60 * 20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            services.AddAuthentication(CustomerAuthorizeAttribute.CustomerAuthenticationScheme)
                    .AddCookie(CustomerAuthorizeAttribute.CustomerAuthenticationScheme, options =>
                    {
                        
                        options.LoginPath = new PathString("/Admin");
                        options.AccessDeniedPath = new PathString("/Home/Error");
                    });
                   
               

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddScheme<AuthenticationSchemeOptions, ApiAuthHandler>("Api", o => { })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                    {
                        // 将任何以/api开头的请求转发到该方案
                        //Foward any requests that start with /api to that scheme
                        options.ForwardDefaultSelector = ctx =>
                        {
                            return ctx.Request.Path.StartsWithSegments("/api") ? "Api" : CookieAuthenticationDefaults.AuthenticationScheme;
                        };
                        options.LoginPath = new PathString("/Admin/User/Login");
                        options.AccessDeniedPath = new PathString("/Home/Error");
                    });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                ;




            // .NET Core 原生依赖注入
            // 单写一层用来添加依赖项，从展示层 Presentation 中隔离
            NativeInjectorBootStrapper.RegisterServices(services);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //注意app.UseAuthentication方法一定要放在下面的app.UseMvc方法前面，否者后面就算调用HttpContext.SignInAsync进行用户登录后，使用
            //HttpContext.User还是会显示用户没有登录，并且HttpContext.User.Claims读取不到登录用户的任何信息。
            //这说明Asp.Net OWIN框架中MiddleWare的调用顺序会对系统功能产生很大的影响，各个MiddleWare的调用顺序一定不能反
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            //Cookie 策略中间件
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
