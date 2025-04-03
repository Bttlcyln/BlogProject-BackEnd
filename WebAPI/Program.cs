using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IUserDal,EfUserDal>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentDal,EfCommentDal>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddTransient<IPostDal,EfPostDal>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddTransient<INotificationDal,EfNotificationDal>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddTransient<ILikeDal,EfLikeDal>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();




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

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
