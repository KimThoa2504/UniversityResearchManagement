using Microsoft.AspNetCore.Authentication.JwtBearer;
using  Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using  UniversityResearchManagement.Data;
using UniversityResearchManagement.Services.Faculties;
using UniversityResearchManagement.Services.ProjectMembers;
using UniversityResearchManagement.Services.Projects;

namespace UniversityResearchManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //MySqlConnection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("MySqlConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
                    )
                );

            //authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("LecturerOnly", policy => policy.RequireRole("Lecturer"));
            });

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(
                    new System.Text.Json.Serialization.JsonStringEnumConverter()
                    );
            });

            //
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            builder.Services.AddScoped<IFacultiesService, FacultiesServiceImpl>();
            builder.Services.AddScoped<IProjectService, ProjectServiceImpl>();
            builder.Services.AddScoped<IProjectMembersService, ProjectMembersServiceImpl>();

            var app = builder.Build();

            app.UseCors("AllowAngular");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
