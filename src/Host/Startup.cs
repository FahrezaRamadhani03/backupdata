// <copyright file="Startup.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using DinkToPdf;
using DinkToPdf.Contracts;
using Garuda.Database.Framework;
using Garuda.Extension.Extensions;
using Garuda.Host.Migrations;
using Garuda.Infrastructure;
using Garuda.Infrastructure.Configurations;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Helpers;
using Garuda.Infrastructure.Middleware;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Sieve.Models;

namespace Garuda.Host
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        private readonly string _extensionsPath;
        private readonly string _pathUpload;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly string customAllowSpecificOrigins = "_customAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"> Get Configuration. </param>
        /// <param name="webHostEnvironment"> Get WebHostEnvironment. </param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // This is the line you would change if your configuration files were somewhere else
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            this._extensionsPath = webHostEnvironment.ContentRootPath + configuration["Extensions:Path"];
            this._pathUpload = webHostEnvironment.ContentRootPath;
            this.hostingEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Configuration Global Service and DI.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            Infrastructure.GlobalConfiguration.WebRootPath = this.hostingEnvironment.WebRootPath;
            Infrastructure.GlobalConfiguration.ContentRootPath = this.hostingEnvironment.ContentRootPath;

            // Add signal R
            services.AddSignalR();

            // Configure Cors Policy
            services.AddCors(o =>
            {
                o.AddPolicy(
                     customAllowSpecificOrigins,
                     builder =>
                     {
                         builder.WithOrigins(this.Configuration["AllowedHosts"])
                             .AllowAnyHeader()
                             .AllowAnyMethod();
                     });

                // cofigure signal R cors
                o.AddPolicy("SignalRClientPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000", "https://internal-web.staging-gi.web.id", "http://localhost:8080")
                        .AllowCredentials();
                });
            });

            services.Configure<JwtIssuerOptions>(this.Configuration.GetSection("JwtIssuerOptions"));

            services.Configure<SieveOptions>(Configuration.GetSection("Sieve"));

            // Initialize Infrastructure it should use extension without addin to project.
            services.AddGarudaCore();

            // configure storage context.
            services.Configure<StorageContextOptions>(options =>
            {
                options.ConnectionString = this.Configuration.GetConnectionString("Connection");
                options.MigrationsAssembly = typeof(DesignTimeStorageContextFactory).GetTypeInfo().Assembly.FullName;
            });

            // initialize DesignTimeStorageContextFactory.
            DesignTimeStorageContextFactory.Initialize(services.BuildServiceProvider());

            // Configure JWT Setting.
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configuring endpoint routing for MVC
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.MaxIAsyncEnumerableBufferLimit = 100000;
            }).AddJsonOptions(jsonOptions =>
            {
                // IgnoreNullValues is obsolete.
                // jsonOptions.JsonSerializerOptions.IgnoreNullValues = true;
                jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            }).AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                opt.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            });

            // Auth
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Web", configureOptions =>
             {
                 configureOptions.RequireHttpsMetadata = false;
                 configureOptions.SaveToken = true;
                 configureOptions.TokenValidationParameters = new TokenValidationParameters
                 {
                     RequireSignedTokens = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SecretKey)])),
                     AuthenticationType = SecurityAlgorithms.HmacSha256,
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero,
                 };
                 configureOptions.Events = new JwtBearerEvents
                 {
                     OnChallenge = async context =>
                     {
                         // Call this to skip the default logic and avoid using the default response
                         context.HandleResponse();
                         context.Response.ContentType = "application/json";
                         context.Response.StatusCode = Codes.INVALID_SESSION;
                         await context.Response.WriteAsJsonAsync(ErrorConstant.UNAUTHORIZED);
                     },
                 };
             });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("Web")
                    .Build();
            });

            // Configure Swagger
            services.AddSwaggerGen(options =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.20220131.001",
                    Title = "Garuda API",
                    Description = "Garuda Api skeleton with .net core with Clean Architecture",
                });

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        jwtSecurityScheme,
                        new List<string>()
                    },
                });

                options.OperationFilter<SwaggerFileOperationFilter>();

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                foreach (var name in Directory.GetFiles(basePath, "*.XML", SearchOption.AllDirectories))
                {
                    options.IncludeXmlComments(name);
                }
            });

            services.AddHangfire(x => x.UseRecommendedSerializerSettings().UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));
            services.AddHangfireServer();

            var architectureFolder = (IntPtr.Size == 8) ? "64bit" : "32bit";
            var libwkhtmltox = string.Empty;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                libwkhtmltox = "libwkhtmltox.dll";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                libwkhtmltox = "libwkhtmltox.so";
            }
            else
            {
                libwkhtmltox = "libwkhtmltox.dylib";
            }

            var wkHtmlToPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox", "v0.12.4", architectureFolder, libwkhtmltox);
            CustomLoadAssembly context = new CustomLoadAssembly();
            context.LoadUnmanagedLibrary(wkHtmlToPdfPath);
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }

        /// <summary>
        /// Configure App and Environment.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("SignalRClientPolicy");

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseStatusCodePages();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseCookiePolicy();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGarudaCore();

            app.UseStaticFiles();

            app.UseHangfireServer();
            RecurringJob.AddOrUpdate<IProjectDetailServices>(x => x.CronJobUpdateStatus(), Cron.Daily);
            RecurringJob.AddOrUpdate<IInvoiceServices>(x => x.CronJobSendEmailInvoiceNotSend(), "5 0 * * *");
            RecurringJob.AddOrUpdate<IInvoiceServices>(x => x.CronJobSendEmailInvoiceNotPaid(), "10 0 * * *");
            RecurringJob.AddOrUpdate<IInvoiceServices>(x => x.CronJobGenerateInvoice(), "15 0 * * *");

            // Configure to register hubs
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notif");
            });
        }
    }
}
