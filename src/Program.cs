using api.customer.Contracts.Responses;
using api.customer.Database;
using api.customer.Middlewares;
using api.customer.Repositories;
using api.customer.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Host.UseSerilog((context, config) => { config.WriteTo.File("logs.txt"); });

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddDbContext<TestContext>(options => options.UseInMemoryDatabase(nameof(TestContext)));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();