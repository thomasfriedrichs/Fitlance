using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Fitlance.Data;
using Fitlance;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Fitlance.Services;
using Fitlance.Entities;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container
//Context
builder.Services.AddDbContext<FitlanceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitlanceDB")));

//Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<FitlanceContext>()
    .AddDefaultTokenProviders();

//Authentication
builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();

builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

//Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TrainerRights", policy =>
        policy.RequireRole(Role.Trainer));
    options.AddPolicy("UserRights", policy =>
        policy.RequireRole(Role.User));
});

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});


//Cors Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDevClient",
        b =>
        {
            b
                .WithOrigins("https://localhost:44458")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    options.AddPolicy("AllowReactDevClient2",
        b =>
        {
            b
                .WithOrigins("https://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseHsts();
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseCors("AllowReactDevClient");
app.UseCors("AllowReactDevClient2");
app.UseStaticFiles();
app.UseRouting();
app.MapFallbackToFile("index.html"); ;
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedManager.Seed(services);
}

app.Run();