
using EduPortal.Data;
using EduPortal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EduPortal.Interfaces;
using EduPortal.Middlewares;
using EduPortal.Models.HelperClasses;
using Microsoft.AspNetCore.Identity;
using EduPortal.Models.Entities;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using EduPortal.RepositoryInterfaces;
using EduPortal.Repositories;

namespace EduPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EduPortal API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT token with **Bearer** prefix. Example: `Bearer eyJhbGciOi...`",
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


            builder.Services.AddHttpContextAccessor();

            // Application Database Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Configure Authentication and Authorization
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)
                        ),
                    ClockSkew = TimeSpan.Zero
                };
            }
            );

            builder.Services.Configure<EmailSettings>(
                builder.Configuration.GetSection("EmailSettings")
            );

            builder.Services.AddScoped<IEmailService, EmailService>();


            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IErrorLogger, ErrorLogger>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

            var app = builder.Build();

            // Middleware Pipeline

            if (app.Environment.IsDevelopment())
            { 
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();


            app.UseAuthentication();  // Checks JWT token
            app.UseAuthorization();   // Checks user roles and permissions

            app.MapControllers();

            app.Run();
        }
    }
}
