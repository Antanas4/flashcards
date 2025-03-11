using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureApp(app);

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddScoped<FlashcardService>();
    services.AddScoped<UserService>();
    services.AddScoped<FlashcardsCollectionService>();

    services.AddAutoMapper(typeof(MappingProfile));

    services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    services.AddControllers();
    services.AddEndpointsApiExplorer();

    services.AddCors(options =>
    {
        options.AddPolicy("AllowBlazorApp", policy =>
        {
            policy.WithOrigins("http://localhost:5039")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
}

void ConfigureApp(WebApplication app)
{
    app.UseCors("AllowBlazorApp");
    // app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllers();
}
