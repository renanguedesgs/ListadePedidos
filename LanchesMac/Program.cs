using LanchesMac.Areas.Admin.Servicos;
using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

var builder = WebApplication.CreateBuilder(args);

// Recupera a string de conexão do arquivo de configuração
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura o DbContext para usar PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connection));  // Altere para UseNpgsql

// Configuração do Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

// Configuração do serviço para imagens
builder.Services.Configure<ConfigurationImagens>(builder.Configuration
    .GetSection("ConfigurationPastaImagens"));

// Configuração dos repositórios
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

// Configuração do serviço para semear roles e usuários
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

// Configuração dos serviços de relatórios e gráficos
builder.Services.AddScoped<RelatorioVendasService>();
builder.Services.AddScoped<GraficoVendasService>();

// Política de autorização para Admin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        politica =>
        {
            politica.RequireRole("Admin");
        });
});

// Configuração do HttpContextAccessor para acessar o contexto HTTP
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configuração do Carrinho de Compra
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

// Configuração das views com paging
builder.Services.AddControllersWithViews();

builder.Services.AddPaging(options =>
{
    options.ViewName = "Bootstrap4";
    options.PageParameterName = "pageindex";
});

// Configuração de cache e sessão
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirecionamento para HTTPS
app.UseHttpsRedirection();

// Arquivos estáticos e roteamento
app.UseStaticFiles();
app.UseRouting();

// Criação de perfis de usuários
CriarPerfisUsuarios(app);

// Configuração de sessões e autenticação
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

#pragma warning disable ASP0014
// Configuração das rotas
app.UseEndpoints(endpoints =>
{
    // Rota para áreas (admin)
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    // Rota para filtro de categorias
    endpoints.MapControllerRoute(
       name: "categoriaFiltro",
       pattern: "Lanche/{action}/{categoria?}",
       defaults: new { Controller = "Lanche", action = "List" });

    // Rota padrão
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

// Método para criar perfis de usuários (roles e usuários)
void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory?.CreateScope())
    {
        var service = scope?.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service?.SeedRoles();
        service?.SeedUsers();
    }
}
