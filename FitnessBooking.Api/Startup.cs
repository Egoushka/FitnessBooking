using Autofac;
using FitnessBooking.Api.Extensions;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Validators;
using FitnessBooking.Data.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FitnessBooking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private EnvironmentDetails environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.DisableCachingForAllHttpCalls();
            environment = services.ConfigurePoco<EnvironmentDetails>(Configuration.GetSection("Environment"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<UserValidator>();
            });
            services.AddAntiforgery(opts => opts.Cookie.Name = "AntiForgery." + environment.ApplicationName);
            services.AddHttpClient();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLongRunningTasks();

            services.AddControllers();

            services.AddResponseCaching(options =>
            {
                options.UseCaseSensitivePaths = true;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = string.Empty,
                    ValidAudience = string.Empty,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Environment:ApplicationSecret"])),
                    ClockSkew = TimeSpan.Zero
                };
                services.AddCors();
            });

            // Add DB Context here
            services.AddDbContext<FitnessBookingContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"),
                options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAllServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");
            app.UseResponseCaching();
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}