using Ecommerce.Api.Extensions;
using ElmahCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddElmahCore(builder.Configuration);
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwaggerUI();
app.UseElmah();

app.Run();
