using BlogPlatform.API.Data;
using BlogPlatform.API.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CORS Policy Setup (NEW) ---
builder.Services.AddCors(options =>
{
    // Defines a policy named 'AngularClient'
    options.AddPolicy("AngularClient", cfg =>
    {
        // Allows requests originating from the Angular development port
        cfg.WithOrigins("http://localhost:4200")
           // Allows any header to be sent
           .AllowAnyHeader()
           // Allows GET, POST, PUT, DELETE, etc. requests
           .AllowAnyMethod();
    });
});
// ----------------------------------

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- 2. Database & Repository Setup ---
var ConnectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(ConnectionString));

// Register the Generic Repository IRepository<T>
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

// --- 3. Applying the CORS Policy (NEW) ---
// MUST be called before app.UseAuthorization() and app.MapControllers()
app.UseCors("AngularClient");
// ----------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();
