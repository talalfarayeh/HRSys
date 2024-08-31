
using HRSystem.BLL.Interfaces;
using HRSystem.BLL.Services;
using HRSystem.DAL.Date;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HrSystemConnection")));
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
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

/*using HRSystem.DAL.Date;
using HRSystem.BLL.Services; //  √ﬂœ „‰ «” Œœ«„ «·‰Ì„ ”»Ì” «·’ÕÌÕ ··Œœ„« 
using HRSystem.BLL.Interfaces; //  √ﬂœ „‰ «” Œœ«„ «·‰Ì„ ”»Ì” «·’ÕÌÕ ··≈‰ —›Ì”
using Microsoft.EntityFrameworkCore;
using HR_Sysytem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HrSystemConnection")));

// Register BLL Services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
*/