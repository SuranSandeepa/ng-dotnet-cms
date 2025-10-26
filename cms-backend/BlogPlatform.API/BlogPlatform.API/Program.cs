using BlogPlatform.API.Data;
using BlogPlatform.API.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(ConnectionString));
//builder.Services.AddScoped<PostsRepository<Post>, SqlRepository<Post>>();
//builder.Services.AddScoped<PostsRepository<Category>, SqlRepository<Category>>();

// Standard Generic Registration:
// Tells DI: "For ANY entity (represented by <>), when the PostsRepository interface is requested, 
// use the SqlRepository implementation."
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

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
