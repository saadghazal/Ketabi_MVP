using Ketabi.Core.Common;
using Ketabi.Core.Repositories;
using Ketabi.Core.Services;
using Ketabi.Infra.Common;
using Ketabi.Infra.Repositories;
using Ketabi.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Ghazal
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext, DbContext>();
//Repository
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookReivewRepository, BookReivewRepository>();


//Service
builder.Services.AddScoped<IBookReivewService, BookReivewService>();
builder.Services.AddScoped<IBookService, BookService>();





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
