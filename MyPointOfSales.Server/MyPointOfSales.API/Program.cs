using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyPointOfSales.API.Extension;
using MyPointOfSales.API.Features.Account;
using MyPointOfSales.API.Features.Items;
using MyPointOfSales.API.Features.Reports;
using MyPointOfSales.API.Features.Transactions;
using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Application.Features.Items;
using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Application.Features.Stocks;
using MyPointOfSales.Application.Features.Transactions;
using MyPointOfSales.Infrastructure.DataContext;
using MyPointOfSales.Infrastructure.Features.Account;
using MyPointOfSales.Infrastructure.Features.Items;
using MyPointOfSales.Infrastructure.Features.Items.ImageHelper;
using MyPointOfSales.Infrastructure.Features.Reports;
using MyPointOfSales.Infrastructure.Features.Stocks;
using MyPointOfSales.Infrastructure.Features.Transactions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new() { Title = "MyPointOfSales_API", Version = "v1" });

    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    o.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = config.GetValue<string>("JwtSettings:Issuer"),
        ValidAudience = config.GetValue<string>("JwtSettings:Audience"),
        ValidAudiences = config.GetValue<string[]>("JwtSettings:Audiences"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("JwtSettings:SignKey")!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.AddAntiforgery();

builder.Services.AddScoped<ItemImageHelper>();
builder.Services.AddScoped<ItemServices>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<ReportsService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IValidator<CreateItemRequest>, CreateItemValidator>();
builder.Services.AddScoped<IValidator<UpdateItemRequest>, UpdateItemValidator>();
builder.Services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidator>();
builder.Services.AddScoped<IValidator<LoginUserRequest>, LoginUserValidator>();
builder.Services.AddScoped<IValidator<PostTransactionRequest>, PostTransactionCommandValidator>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IUserRepoSitory, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ITokenRepoSitory, TokenRepository>();

builder.Services.AddCors(cors =>
    cors.AddPolicy("BlazorCors", policy =>
    {
        policy.WithOrigins("http://localhost:5231", "https://localhost:7200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    })
);

var app = builder.Build();

app.ApplyMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("BlazorCors");
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapItemEndpoint();
app.MapAccountEndpoint();
app.MapTransactionEndpoint();
app.MapReportEndpoint();
app.MapStockEndpoint();

app.Run();