using Api;
using Api.Extensions;
using Application;
using Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfraestructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();