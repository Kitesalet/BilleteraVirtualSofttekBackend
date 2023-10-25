using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Infrastructure;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.HelperClasses;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using BilleteraVirtualSofttekBack.Services;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using IntegradorSofttekImanol.DAL.UnitOfWork;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var allowSpecificOrigins = "";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins, policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});


builder.Services.AddHttpClient("useApi", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ApiUrl"]);
});

//Serilog configuration and file path

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/VirtualWalletLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Services.AddLogging(logging => logging.AddSerilog());



#region Scoped Services

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();  

builder.Services.AddScoped<IRepository<BaseAccount>, Repository<BaseAccount>>();
builder.Services.AddScoped<IRepository<Client>, Repository<Client>>();
builder.Services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();

builder.Services.AddScoped<AccountFactory>();

#endregion

// Configure Swagger to add an authorize token field
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UmsaSofttek", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
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
            }, new string[]{}
        }
    });
});

builder.Services.AddAutoMapper(typeof(MapperHelper));
builder.Services.AddDbContext<AppDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region JWT Configuration

// Gets JWT parameters from appsettings.json, mapping the properties from JSON to the object.
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// Adds JWT authorization as a service, defining Bearer as the authentication scheme, and setting parameters for JWT token validation.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
    });

// Adds JWT configuration to make it available.
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

#endregion

#region JWT Authentication

// Adds authorization based on policies and roles in our JWT.
builder.Services.AddAuthorization(option =>
{
    //Creates policies for both the Admin and Base roles,based on their PKs
    option.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    option.AddPolicy("Base", policy => policy.RequireClaim(ClaimTypes.Role, "Base"));

    //Creates a policy that authorizes a token if their Role claim is either 1 or 2 ( Admin or Base )
    option.AddPolicy("AdminOrBase", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Base"));

});

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors(allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
