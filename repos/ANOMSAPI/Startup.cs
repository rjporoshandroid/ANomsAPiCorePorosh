using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANOMS.Domain.Entities;
using ANOMS.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger;

namespace ANOMSAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));

            services.AddMvcCore().AddApiExplorer();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:4200",
                                                        "http://localhost:61970",
                                                        "https://ajkerdeal.com",
                                                        "https://content.ajkerdeal.com",
                                                        "https://localhost:61970",
                                                        "http://localhost:61851",
                                                        "http://localhost:1088",//Aowal Vai
                                                        "http://localhost:1038",//Aowal Vai
                                                        "http://localhost:16220",//Porosh Vai
                                                        "http://localhost:50707",//Emon Vai
                                                        "http://complain.ajkerdeal.com",//Forid Vai
                                                        "http://localhost:8885",//Forid Vai
                                                        "http://localhost:26963"//Aowal Vai
                                                        ).AllowAnyHeader().AllowAnyMethod();

                                });
            });

            var secret = "This is code is very important.Because it is a secret";
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
               // c.SwaggerDoc("v1", new Info { title = "My API", Version = "v1" });
            });
            //  services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddTransient<IContentPanelRepository, ContentPanelRepository>();
            //services.AddTransient<IContentPanelService, ContentPannelService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //[Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My ANOMS API");
            });

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();

            app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

        }
    }
}
