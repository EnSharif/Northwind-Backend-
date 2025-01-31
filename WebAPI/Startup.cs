using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowOrigin",
        //            builder => builder.WithOrigins("https://localhost:4200"));
        //    });
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo
        //        {
        //            Title = "My API",
        //            Version = "v1"
        //        });
        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            In = ParameterLocation.Header,
        //            Description = "Insert JWT token in the format: Bearer {token}",
        //            Name = "Authorization",
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });
        //        services.AddCors(options =>
        //        {
        //            options.AddPolicy("AllowOrigin", builder =>
        //            {
        //                builder.WithOrigins("https://localhost:4200", "http://localhost:4200")
        //                    .AllowAnyHeader()
        //                    .AllowAnyMethod();
        //            });
        //        });


        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    }
        //                },
        //                Array.Empty<string>()
        //            }
        //        });

        //        var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        //        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //            .AddJwtBearer(options =>
        //            {
        //                options.TokenValidationParameters = new TokenValidationParameters
        //                {
        //                    ValidateIssuer = true,
        //                    ValidateAudience = true,
        //                    ValidateLifetime = true,
        //                    ValidateIssuerSigningKey = true,
        //                    ValidIssuer = tokenOptions.Issuer,
        //                    ValidAudience = tokenOptions.Audience,
        //                    IssuerSigningKey = SecurityKeyHelper.CreateSecurtyKey(tokenOptions.SecurityKey)

        //                };
        //            });

        //    });
        //}

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c =>
        //        {
        //            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        //        });

        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        app.UseHsts();
        //    }

        //    app.UseCors("AllowOrigin");
        //    //app.UseCors(builder => builder.WithOrigins("https://localhost:4200").AllowAnyHeader());
        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();
        //    app.UseRouting();
        //    app.UseAuthentication();
        //    app.UseAuthorization();


        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // CORS konfigurieren
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("https://localhost:4200", "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            // JWT-Authentifizierung hinzufügen
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });

            // Swagger konfigurieren
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Füge das JWT-Token im Format 'Bearer {token}' ein.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"); });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Authentication-Middleware
            app.UseAuthorization(); // Authorization-Middleware

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }



}