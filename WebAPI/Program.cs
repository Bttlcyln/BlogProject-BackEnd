using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddTransient<IUserDal,EfUserDal>();
builder.Services.AddScoped<ICommentService, CommetManager>();
builder.Services.AddTransient<ICommentDal,EfCommentDal>();
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddTransient<IPostDal,EfPostDal>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
