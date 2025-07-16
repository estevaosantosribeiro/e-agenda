using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloCompromissos;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloCategoria;
using EAgenda.Infraestrutura.Arquivos.ModuloCompromisso;
using EAgenda.Infraestrutura.Arquivos.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.ModuloDespesa;
using EAgenda.Infraestrutura.Arquivos.ModuloTarefa;
using EAgenda.Infraestrutura.Orm.Compartilhado;
using EAgenda.Infraestrutura.Orm.ModuloContato;
using EAgenda.WebApp.ActionFilters;
using EAgenda.WebApp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<ContextoDados>((_) => new ContextoDados(true));
        builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        builder.Services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmArquivo>();
        builder.Services.AddScoped<IRepositorioContato, RepositorioContatoEmOrm>();
        builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmArquivo>();
        builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmArquivo>();

        builder.Services.AddEntityFrameworkConfig(builder.Configuration);

        var app = builder.Build();

        app.UseAntiforgery();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
