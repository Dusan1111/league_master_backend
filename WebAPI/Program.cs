using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System;
using System.Text.Json.Serialization;
using League_Master.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var LeagueMasterAllowSpecificOrigins = "_leagueMasterAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddDbContext<LeagueMasterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Infrastructure")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LeagueMasterAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins().AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();
                      });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole",
         policy => policy.RequireRole("Admin"));

    options.AddPolicy("RequireRefereeRole",
        policy => policy.RequireRole("Referee"));

    options.AddPolicy("RequireAdminOrRefereeRole",
        policy => policy.RequireRole("Admin", "Referee"));
});

builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("LeagueMaster", new OpenApiInfo { Title = "LeagueMaster API", Version = "v1" });
    c.SwaggerDoc("LeagueMasterBackoffice", new OpenApiInfo { Title = "LeagueMaster Backoffice API", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// sesion 
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:SecretKey"]))
        };
    });

builder.Services.AddMvc();

var app = builder.Build();

app.UseCors(LeagueMasterAllowSpecificOrigins);

// add use auth zbog logina i tokena
app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.UseSession();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();