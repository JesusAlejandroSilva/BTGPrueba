using BTGFunds.Application.Interfaces;
using BTGFunds.Application.Services;
using BTGFunds.Infrastructure.Mongo;
using BTGFunds.Infrastructure.Repositories.Implementation;
using BTGFunds.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<FundRepository>();
builder.Services.AddScoped<SubscriptionRepository>();
builder.Services.AddScoped<TransactionRepository>();

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddScoped<FundService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();