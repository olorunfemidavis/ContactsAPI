using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Backend.Services;
using ContactsAPI.Shared.Models.General;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(GeneralMapping));

//Register the Database
builder.Services.AddSingleton<LiteDbService>();

builder.Services.AddSingleton<IJwtAuthentication, AuthService>();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

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