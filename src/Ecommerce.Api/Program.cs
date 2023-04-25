using Ecommerce.Api.Extensions;
using Ecommerce.Infra.Context;
using ElmahCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddElmahCore(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.UseSqlServer(builder.Configuration);
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwaggerUI();
app.UseElmah();

app.Run();
