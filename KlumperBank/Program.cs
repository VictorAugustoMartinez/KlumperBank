using KlumperBank.Data;
using KlumperBank.Repositories.Contracts;
using KlumperBank.Repositories;

var builder = WebApplication.CreateBuilder(args);

//resolvendo dependencias
builder.Services.AddDbContext<KlumperBankDtContext>();
builder.Services.AddTransient<IGetUserRepository, GetUserRepository>();
builder.Services.AddTransient<IPostUserRepository, PostUserRepository>();
builder.Services.AddTransient<IUpdateUserRepository, UpdateUserRepository>();


builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
