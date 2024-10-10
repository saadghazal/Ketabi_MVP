using Ketabi;
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

builder.Services.AddScoped<Helpers>();

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookReviewRepository, BookReviewRepository>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();

builder.Services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
//Services
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookReviewService, BookReviewService>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped<IBorrowedBookService, BorrowedBookService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IFavoriteBookRepository, FavoriteBookRepository>();
builder.Services.AddScoped<IFavoriteBookService, FavoriteBookService>();

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
