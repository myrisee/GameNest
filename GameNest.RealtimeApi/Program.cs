using GameNest.Application.CQRS.Requests;
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
builder.Services.AddScoped<JwtOptions>();
builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
builder.Services.AddScoped(typeof(IItemRepository), typeof(ItemRepository));
builder.Services.AddScoped(typeof(IItemInstanceRepository), typeof(ItemInstanceRepository));
builder.Services.AddScoped(typeof(IClanRepository), typeof(ClanRepository));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterRequest).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPlayerAccessor, PlayerAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtConfigurationOptions>();
builder.Services.ConfigureOptions<JwtBearerConfigurationOptions>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddGrpc();
builder.Services.AddMagicOnion();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapMagicOnionService();
app.MapGet("/", () => "GameNest Realtime API is running!");
app.Run();