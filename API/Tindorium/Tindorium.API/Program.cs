var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
//builder.Services.AddSingleton

var app = builder.Build();

app.UseCors(builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();


