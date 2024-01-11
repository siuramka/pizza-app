using Microsoft.EntityFrameworkCore;
using PresentPizza.Business.Services;
using PresentPizza.DataAccess;
using PresentPizza.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PresentPizzaContext>(options =>
    options.UseInMemoryDatabase("PizzaDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddScoped<PizzaOrderRepository>();
builder.Services.AddScoped<PizzaOrderToppingRepository>();
builder.Services.AddScoped<ToppingRepository>();
builder.Services.AddTransient<PizzaOrderService>();
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
await dbSeeder.SeedData();

app.Run();