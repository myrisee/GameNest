using GameNest.Application.CQRS.Requests;
using GameNest.Application.CQRS.Requests.Auth;
using GameNest.Application.Interfaces;
using GameNest.Infrastructure.Authentication;
using GameNest.Persistence.Context;
using GameNest.Persistence.Repository;
using GameNest.RealtimeApi;
using GameNest.RealtimeApi.ConfigureOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(endpointOptions =>
    {
        endpointOptions.Protocols = HttpProtocols.Http2;
    });
});

// Add services to the container.
builder.Services.AddScoped<GameNestContext>();
builder.Services.AddSingleton<JwtOptions>();
builder.Services.AddSingleton<JwtProvider>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
builder.Services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
builder.Services.AddScoped(typeof(IItemInstanceRepository), typeof(ItemInstanceRepository));
builder.Services.AddScoped(typeof(IClanRepository), typeof(ClanRepository));
builder.Services.AddScoped(typeof(ILoadoutRepository), typeof(LoadoutRepository));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterRequest).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPlayerAccessor, PlayerAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Gatherly",
            ValidAudience = "Gatherly",
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super-secret-key-value-1234567890abcd!@#1234567890abcd"))
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                return Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();

builder.Services.AddGrpc();
builder.Services.AddMagicOnion();

var app = builder.Build();

// gRPC metadata'dan Authorization header'ını HTTP header'a taşıyan middleware
app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
    if (!string.IsNullOrEmpty(authHeader) && authHeader.Contains(","))
    {
        var firstToken = authHeader.Split(',')[0].Trim();
        context.Request.Headers["Authorization"] = firstToken;
        Console.WriteLine($"[Middleware] Multiple tokens detected. Using first: {firstToken}");
    }
    await next();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapMagicOnionService();
app.MapGet("/", () => "GameNest Realtime API is running!");
app.Run();