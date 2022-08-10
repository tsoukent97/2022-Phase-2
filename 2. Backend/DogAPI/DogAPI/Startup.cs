using DogAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace DogAPI
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
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultSQLConnection"));
            });

            services.AddControllers(option =>
            {
                //option.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson();

            services.AddSwaggerDocument(options =>
            {
                options.DocumentName = "DogAPI";
                options.Version = "V1";

            });
            services.AddHttpClient("reddit", configureClient: client =>
            {
                client.BaseAddress = new Uri("https://www.reddit.com/dev/api");
            });
            services.AddHttpClient("dog", configureClient: client =>
            {
                client.BaseAddress = new Uri("https://dog.ceo/api/breeds/list/all");
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

