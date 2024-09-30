using HortifrutiMvc.Data;
using HortifrutiMvc.Repositories;
using HortifrutiMvc.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionar o serviço do contexto do banco de dados
builder.Services.AddDbContext<HortifrutiMvcContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios genéricos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Registrar serviços genéricos
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

// Registrar serviços específicos
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FornecedorService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<VendaService>();
builder.Services.AddScoped<ItensVendaService>();
builder.Services.AddScoped<DadosPessoaisService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
