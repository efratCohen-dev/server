using Microsoft.EntityFrameworkCore;
using Models;
using DAL.Data;
using DAL.Interfaces;
using DBFirst.MiddleWare;
using Serilog;

string myCors = "_myCors";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddCors(op =>
//{
//   op.AddPolicy(Cors, builder =>
//   {
//      builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
//   });
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodo, Todo>();
builder.Services.AddScoped<IUsers,Users>();
builder.Services.AddScoped<IPhoto, Photo>();
builder.Services.AddScoped<IPost, Post>();
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer("Data Source=DESKTOP-5LPOSL4;Initial Catalog=ProjektDBFirstEfrat;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddCors(op =>
{
    op.AddPolicy(myCors,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myCors);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(@"C:\Users\user\Desktop\תיכנות\יד\פרוייקט חנוכה\DBFirst.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
app.UseMiddleware<GlobalErorr>();
app.UseMiddleware<MiddleWare>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
