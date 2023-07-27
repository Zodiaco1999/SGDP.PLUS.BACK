using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.Middleware;
using SGDP.PLUS.SEG;

var builder = WebApplication.CreateBuilder(args);
string SpecificOrigins = "specificOrigins";

var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(SpecificOrigins,
    builder =>
    {
        builder.WithOrigins(corsOrigins!).AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddSingleton<IContextAccessor, ContextAccessor>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplicacionesServices(builder.Configuration);

// Añadir autentificación el Aplicación por JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("JWT:Secreto").Value!)),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

app.UseCors(SpecificOrigins);
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.UseMiddleware<CustomExceptionMiddleware>();

app.UseRequestLocalization();


app.Run();
