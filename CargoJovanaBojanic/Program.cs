using Core.Common;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Models.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductCategoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));

builder.Services.AddScoped<ProductCategoryDbContext>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
