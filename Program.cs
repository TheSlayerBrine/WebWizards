using Microsoft.EntityFrameworkCore;
using WebWizards.Data;
using WebWizards.Data.Repositories;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.Services.ServiceObjects.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer("Data Source=DESKTOP-NFKHDAA\\SQLEXPRESS01;Initial Catalog=WebWizards;Integrated Security=True;TrustServerCertificate=true"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped <IPostRepository, PostRepository>();
builder.Services.AddScoped <ILikeRepository, LikeRepository>();
builder.Services.AddScoped <IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped <ILikeService, LikeService>();
builder.Services.AddSwaggerGen();

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
