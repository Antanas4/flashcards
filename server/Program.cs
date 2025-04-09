using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using server.Services;
using server.MapperProfile;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

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

    // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // .AddJwtBearer(options =>
    // {
    //     options.TokenValidationParameters = new TokenValidationParameters
    //     {
    //         ValidateIssuer = true,
    //         ValidateAudience = true,
    //         ValidateLifetime = true,
    //         ValidateIssuerSigningKey = true,
    //         ValidIssuer = builder.Configuration["Jwt:Issuer"],
    //         ValidAudience = builder.Configuration["Jwt:Audience"],
    //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    //     };
    // });
    
    builder.Services.AddSingleton<TokenProvider>();
}

void ConfigureApp(WebApplication app)
{
    app.UseCors("AllowBlazorApp");
    // app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllers();
}
