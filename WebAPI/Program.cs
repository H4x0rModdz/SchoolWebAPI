using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repository;
using WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IAppDbContext, AppDbContext>();

builder.Services.AddScoped<ISchoolSubjectService, SchoolSubjectService>();
builder.Services.AddScoped<ISchoolSubjectRepository, SchoolSubjectRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllers();
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