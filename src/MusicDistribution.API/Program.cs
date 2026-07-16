using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MusicDistribution.API;
using MusicDistribution.API.Middleware;
using MusicDistribution.Application.Validators.Track;
using MusicDistribution.Persistence.Data;
using MusicDistribution.Persistence.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
//custom validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateTrackValidator>();
// andding debendancies
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//db context service
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
}



app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();


app.Run();

