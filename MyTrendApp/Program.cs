using Microsoft.EntityFrameworkCore;
using MyTrendApp.Data;
using MyTrendApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the DbContext with Oracle.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));


    // Register application services.
    builder.Services.AddHttpClient<IAuthService, AuthService>();
    
builder.Services.AddScoped<AvaliacaoService>();
builder.Services.AddScoped<CategoriaProdutoService>();
builder.Services.AddScoped<CorService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PerfilUsuarioService>();
builder.Services.AddScoped<RecomendacaoLookService>();
builder.Services.AddScoped<FeedbackUsuarioService>();
builder.Services.AddScoped<RoupaService>();

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
