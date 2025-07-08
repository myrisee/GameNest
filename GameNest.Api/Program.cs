using GameNest.Application.Interfaces;
using GameNest.Persistence.Context;
using GameNest.Persistence.Repository;
using GameNest.WebApi;
using GameNest.Application.CQRS.Commands;
using GameNest.Application.CQRS.Requests;
using GameNest.Infrastructure.Authentication;
using GameNest.WebApi.ConfigureOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtConfigurationOptions>();
builder.Services.ConfigureOptions<JwtBearerConfigurationOptions>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
