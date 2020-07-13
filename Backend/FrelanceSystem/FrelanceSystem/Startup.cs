using BussinessLayer.Factories;
using BussinessLayer.Utils;
using DataAccessLayer;
using FrelanceSystem.SecurityKeys;
using FrelanceSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;

namespace FrelanceSystem
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
            services.AddControllers();
            services.AddSwaggerGen();

            const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234ns4t1230";
            var signingKey = new SigningSymmetricKey(signingSecurityKey);

            ILogger logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build())
                .CreateLogger();

            services.AddSingleton(logger);
            services.AddSingleton<IJwtSigningEncodingKey>(signingKey);
            services.AddTransient<IUsersManager, UsersManager>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IAccountUtils, AccountUtils>();

            const string jwtSchemeName = "JwtBearer";
            var signingDecodingKey = (IJwtSigningDecodingKey)signingKey;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = jwtSchemeName;
                options.DefaultChallengeScheme = jwtSchemeName;
            }).AddJwtBearer(jwtSchemeName, jwtBearerOptions =>
             {
                 jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = signingDecodingKey.GetKey(),

                     ValidateIssuer = true,
                     ValidIssuer = "FreelanceSystem server",

                     ValidateAudience = true,
                     ValidAudience = "FreelanceSystem client",

                     ValidateLifetime = true,

                     ClockSkew = TimeSpan.FromSeconds(5)
                 };
             });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
