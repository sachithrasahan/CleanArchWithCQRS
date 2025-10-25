using Application.Customers.Commands.Handlers;
using Application.Interfaces;
using Infrastructure.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerHandler));
});

// Register in-memory DB and generic repository
builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(InMemoryRepository<>));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
