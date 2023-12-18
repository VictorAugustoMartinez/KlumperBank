using KlumperBank;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);


var smtp = new Settings.SmtpConfiguration();
app.Configuration.GetSection("SmtpConfiguration").Bind(smtp);
Settings.Smtp = smtp;


app.Run();