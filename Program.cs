using Evaluation.Interfaces;
using Evaluation.Mapping;
using Evaluation.Models;
using Evaluation.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = builder.Configuration.GetConnectionString("HostingConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ProTradeDbContext>().AddDefaultTokenProviders();
builder.Services.AddCors();
var issuer = builder.Configuration["JWT:ValidIssuer"];
var audience = builder.Configuration["JWT:ValidAudience"];
var secret = builder.Configuration["JWT:Secret"];



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
