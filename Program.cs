using FoodShareAPI.Datos;
using Microsoft.EntityFrameworkCore;
using FoodShareAPI.Interfaces;
using FoodShareAPI.Repositorios;
using FoodShareAPI.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// Agregar servicios
// ==========================================
builder.Services.AddControllers();

builder.Services.AddDbContext<FoodShareDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ==========================================
// Repositorios
// ==========================================
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDonacionRepository, DonacionRepository>();
builder.Services.AddScoped<ISolicitudRepository, SolicitudRepository>();
builder.Services.AddScoped<IEntregaRepository, EntregaRepository>();

// ==========================================
// Servicios
// ==========================================
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDonacionService, DonacionService>();
builder.Services.AddScoped<ISolicitudService, SolicitudService>();
builder.Services.AddScoped<IEntregaService, EntregaService>();

// ==========================================
// Integración con Groq - Inteligencia Artificial
// ==========================================
builder.Services.AddHttpClient<IGroqService, GroqService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(60);
});

// ==========================================
// Configuración JWT
// ==========================================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]!
                )
            )
        };
    });

// ==========================================
// Swagger
// ==========================================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new Microsoft.OpenApi.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.ParameterLocation.Header,
            Description = "Ingresa el token JWT"
        }
    );

    options.AddSecurityRequirement(document =>
        new Microsoft.OpenApi.OpenApiSecurityRequirement
        {
            [new Microsoft.OpenApi.OpenApiSecuritySchemeReference(
                "Bearer",
                document
            )] = []
        });
});

// ==========================================
// Construcción de la aplicación
// ==========================================
var app = builder.Build();

// ==========================================
// Middleware
// ==========================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ==========================================
// Autenticación y autorización
// ==========================================
app.UseAuthentication();
app.UseAuthorization();

// ==========================================
// Controladores
// ==========================================
app.MapControllers();

app.Run();