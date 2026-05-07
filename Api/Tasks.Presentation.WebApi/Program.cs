using Serilog;
using Tasks.Application.UseCases;
using Tasks.Infrastructure.Persistence;
using Tasks.Presentation.WebApi.Middlewares;
using Tasks.Presentation.WebApi.Modules.Feature;
using Tasks.Presentation.WebApi.Modules.Injection;
using Tasks.Presentation.WebApi.Modules.Mapper;
using Tasks.Presentation.WebApi.Modules.Swagger;
using Tasks.Presentation.WebApi.Modules.Validator;
using Tasks.Shared.Logging;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter()
        );
    });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddUseCasesServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInjection(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddTransversalServices(builder.Configuration);

builder.Host.UseSerilog();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();   
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1");
    });
}

app.UseCors("frontpolicy");
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
