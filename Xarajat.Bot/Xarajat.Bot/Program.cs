using Microsoft.EntityFrameworkCore;
using Xarajat.Bot.Options;
using Xarajat.Bot.Repositories;
using Xarajat.Bot.Services;
using Xarajat.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<XarajatDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("XarajatBotDb"));
});

builder.Services.Configure<XarajatBotOptions>(
    builder.Configuration.GetSection(nameof(XarajatBotOptions)));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TelegramBotService>();
builder.Services.AddScoped<RoomRepository>();


builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();