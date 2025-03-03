var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("http://localhost:5039")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// app.UseCors("AllowBlazorApp");

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
