using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Repositories;
using TalentoTrack.Common.Services;
using TalentoTrack.Dao.DB;
using TalentoTrack.Dao.Repositories;
using TalentoTrack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AddTransient means it will always create object whenever we require that => once used it will destroy that object
//AddSingleton means it will always create one object across whole lifecycle of program
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//builder.Services.AddDbContext<TalentoTrack_DbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"))); this or below is also ok
builder.Services.AddDbContext<TalentoTrack_DbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
//builder.Configuration.GetConnectionString("DefaultConnection"); this or above is also ok


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
