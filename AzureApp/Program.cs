using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        name: "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Azure App",
            Description = "Azure App"
        });
});
//builder.Services.AddSwaggerGenNewtonsoftSupport();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "../swagger/v1/swagger.json", name: "Azure App");
    options.DefaultModelsExpandDepth(-1);
    options.SupportedSubmitMethods(new SubmitMethod[] { SubmitMethod.Get, SubmitMethod.Post });

    //options.DisableValidator();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
