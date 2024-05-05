using api_service.Extensions;
using DataAccess.Extensions;
using Repositories.Extensions;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddDapperContext();
builder.Services.AddDatabaseMigration(builder.Configuration);

var app = builder.Build();
app.MapControllers();
app.UseAuthorization();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI();

app.Services.CreateScope().ServiceProvider.MakeMigrate();

app.Run();