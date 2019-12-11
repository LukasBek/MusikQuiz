using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusikQuiz.DAO;
using MusikQuiz.Data;
using MusikQuiz.Models;

namespace MusikQuiz
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
            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));


            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUserDao, UserDao>();
            services.AddScoped<IQuizDao, QuizDao>();
            services.AddScoped<ICategoryDao, CategoryDao>();
            services.AddScoped<ISoundDao, SoundDao>();
            services.AddScoped<ITagDao, TagDao>();


            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSession();

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>(); 
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseMvcWithDefaultRoute();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action=Index}/{id?}");
            });
            
            app.UseAuthorization();
            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            */
        }
    }
}
