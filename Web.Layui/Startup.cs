using CrossCutting;
using CrossCutting.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
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
            //����������,HttpContext.Current��Χ�����ҵ���߼�
            services.AddHttpContextAccessor();
            //�������� HstsOptions ��ί�С�
            services.AddHsts(options =>
            {
                options.Preload = true;//�����ϸ��䰲ȫ��ͷ��Ԥ�ز�����
                options.IncludeSubDomains = true;//�����ϸ���-��ȫ��ͷ�� includeSubDomain ������
                options.MaxAge = TimeSpan.FromDays(60);//�����ϸ��䰲ȫ��ͷ����������ڲ�����
                options.ExcludedHosts.Add("");//�������� HSTS ��ͷ���������б�
            });
            services.AddSameSiteCookiePolicy();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();//�ֲ�ʽ�ڴ滺��
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000 * 60 * 20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthorization();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                    {
                        o.LoginPath = new PathString("/Admin/User/Login");
                        o.ForwardSignOut = new PathString("/");
                        //o.AccessDeniedPath = new PathString("/Error/Forbidden");
                    });
            // .NET Core ԭ������ע��
            // ��дһ�����������������չʾ�� Presentation �и���
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

            //ע��app.UseAuthentication����һ��Ҫ���������app.UseMvc����ǰ�棬���ߺ���������HttpContext.SignInAsync�����û���¼��ʹ��
            //HttpContext.User���ǻ���ʾ�û�û�е�¼������HttpContext.User.Claims��ȡ������¼�û����κ���Ϣ��
            //��˵��Asp.Net OWIN�����MiddleWare�ĵ���˳����ϵͳ���ܲ����ܴ��Ӱ�죬����MiddleWare�ĵ���˳��һ�����ܷ�
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            //Cookie �����м��
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