using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using QuoteCalculatorAPI.Models;
using QuoteCalculatorAPI.Models.Data;
using QuoteCalculatorAPI.Repositories.Implementations;
using QuoteCalculatorAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(policy => policy.AddPolicy("QuoteMVCLocal",build =>
{
    string quoteMvcLocalDomain = builder.Configuration.GetValue<string>("quoteCalculatorBaseEndpoint");

    build.WithOrigins(quoteMvcLocalDomain.Substring(0,quoteMvcLocalDomain.Length-1))
    .AllowAnyMethod()
    .AllowAnyHeader();

}))
.AddCors(policy => policy.AddPolicy("All",build =>
{
    build.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Db connection
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbCon")));

//DI for our repositories
builder.Services.AddScoped<IQuoteRepository<QuoteInformation>, QuoteRepository>();
builder.Services.AddScoped<IQuotePaymentRepository<QuotePayment>, QuotePaymentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// CORS middleware
app.UseCors("QuoteMVCLocal");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
