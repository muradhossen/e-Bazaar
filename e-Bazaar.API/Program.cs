using Infrastructure;
using Application;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Pagination;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddPersistence(builder.Configuration)
    .AddInfrastructure()
    .AddApplication();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

 

 app.MapControllers();

app.Run();

