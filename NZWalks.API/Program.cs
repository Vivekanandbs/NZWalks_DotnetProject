
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.IRepository;
using NZWalks.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace NZWalks.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authorisation header using the bearer scheme. Enter Bearer [space] add token in the text input.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"   
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Id = "Bearer",
                               Type = ReferenceType.SecurityScheme
                           },
                           Scheme = "oauth2",
                           Name = " Bearer",
                           In = ParameterLocation.Header
                       },
                       new List<string>()
                    }     
                });
            });

            builder.Services.AddDbContext<NZWalksContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

            builder.Services.AddScoped<IDifficultyRepo, DifficultyRepo>();
            builder.Services.AddScoped<IRegionRepo, RegionRepo>();
            builder.Services.AddScoped(typeof(INzWalksRepo<>), typeof(NzWalksRepo<>));

            builder.Services.AddCors(option => option.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            }));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecretKey"))),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("LocalIssuer"),

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration.GetValue<string>("LocalAudience")
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
