using KlumperBank.Data;
using KlumperBank.Repositories.Contracts;
using KlumperBank.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using KlumperBank;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);


app.Run();
