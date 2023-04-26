using Ecommerce.Api.Extensions;
using ElmahCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddElmahCore(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddApiVersioningConfigured();
builder.Services.UseSqlServer(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwaggerUI();
app.UseElmah();

app.Run();
