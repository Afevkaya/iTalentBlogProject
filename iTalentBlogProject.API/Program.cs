using System.Reflection;
using FluentValidation.AspNetCore;
using iTalentBlogProject.API.Filters;
using iTalentBlogProject.Core.Repositories;
using iTalentBlogProject.Core.Services;
using iTalentBlogProject.Core.UnitOfWorks;
using iTalentBlogProject.Repository.Context;
using iTalentBlogProject.Repository.Repositories;
using iTalentBlogProject.Repository.UnitOfWorks;
using iTalentBlogProject.Services.Mapping;
using iTalentBlogProject.Services.Services;
using iTalentBlogProject.Services.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=> options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreatePostDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<iTalentBlogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(iTalentBlogContext)).GetName().Name);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Generic
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

// Type
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();




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
