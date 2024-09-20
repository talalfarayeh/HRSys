
using HR_System.BLL.Sarvices;
using HR_System.BLL.Sarvices.Interfaces;
using HR_Sysytem.API;
using HRSystem.BLL.Interfaces;
using HRSystem.BLL.Services;
using HRSystem.DAL.Date;
using HRSystem.DAL.Repositories;
using HRSystem.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HrSystemConnection"), b => b.MigrationsAssembly("HRSystem.DAL")));
 
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
// ����� ������� JWT �� appsettings.json
var jwtOptionsSection = builder.Configuration.GetSection("JWT");
builder.Services.Configure<JwtOptions>(jwtOptionsSection);

// ������� ������� JWT
var jwtOptions = jwtOptionsSection.Get<JwtOptions>();

// ����� JwtOptions ����� Singleton ���� ����� ��� DI
builder.Services.AddSingleton(jwtOptions);

// ����� �������� �������� JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),

            ValidateLifetime = true, // ������ �� ������ ������
            ClockSkew = TimeSpan.Zero // ����� ������� �� ������ �� ������ ��������
        };
    });

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

 