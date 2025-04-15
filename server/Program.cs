using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using server.Services;
using server.MapperProfile;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

DotEnv.Load();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureApp(app);

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddScoped<FlashcardService>();
    services.AddScoped<UserService>();
    services.AddScoped<FlashcardsCollectionService>();
    services.AddScoped<AuthService>();
    services.AddHttpContextAccessor();

    services.AddAutoMapper(typeof(FlashcardMapperProfile),
                        typeof(FlashcardsCollectionMapperProfile),
                        typeof(UserMapperProfile));


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

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")))
        };
    });

    builder.Services.AddSingleton<TokenProvider>();
}

void ConfigureApp(WebApplication app)
{
    app.UseCors("AllowBlazorApp");
    // app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseStaticFiles();
    app.MapControllers();
}
