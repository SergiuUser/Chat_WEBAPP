using Chat_WEBAPP.Context;
using Chat_WEBAPP.Controllers;
using Chat_WEBAPP.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,   // Set to false to skip issuer validation
            ValidateAudience = false, // Set to false to skip audience validation
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretJWTKey"]))
        };
    });

builder.Services.AddScoped<AuthService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new AuthService(configuration);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChatContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnStr")));

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
