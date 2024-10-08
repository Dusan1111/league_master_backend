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
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Services;
using Infrastructure.Repositories;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Hosting;

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
    //c.SwaggerDoc("LeagueMasterBackoffice", new OpenApiInfo { Title = "LeagueMaster Backoffice API", Version = "v1" });
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


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>(); 
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<ITeamService, TeamService>();

builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IStatisticsService, StatisticsService>();

builder.Services.AddTransient<ILeagueRepository, LeagueRepository>();
builder.Services.AddTransient<ILeagueService, LeagueService>();

builder.Services.AddMvc();

var app = builder.Build();

app.UseCors(LeagueMasterAllowSpecificOrigins);

//if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Localhost") || app.Environment.IsStaging())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/Loyalty/swagger.json", "Loyalty API V1");
//        c.SwaggerEndpoint("/swagger/Backoffice/swagger.json", "Backoffice API V1");
//    });
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/LeagueMaster/swagger.json", "LeagueMaster API V1");
    //c.SwaggerEndpoint("/swagger/LeagueMasterBackoffice/swagger.json", "LeagueMaster Backoffice API V1");
});

// add use auth zbog logina i tokena
app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.UseSession();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();