using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using EAgenda.Infraestrutura.Arquivos.ModuloCategoria;
using EAgenda.Infraestrutura.Arquivos.ModuloCompromisso;
using EAgenda.Infraestrutura.Arquivos.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.ModuloDespesa;
using EAgenda.Infraestrutura.Arquivos.ModuloTarefa;
using EAgenda.WebApp.ActionFilters;

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
        builder.Services.AddScoped<IRepositorioContato, RepositorioContatoEmArquivo>();
        builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmArquivo>();
        builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmArquivo>();

        var app = builder.Build();

        app.UseAntiforgery();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
