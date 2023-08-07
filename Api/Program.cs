using Api.Common.Infra.DataBase;
using Api.Modules.UserModule.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<Context>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

//app cors
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsapp");

app.UseAuthorization();
app.MapControllers();



app.Run();
