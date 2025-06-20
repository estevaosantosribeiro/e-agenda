using EAgenda.Dominio.ModuloCategoria;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class CategoriaExtensions
{
    public static Categoria ParaEntidade(this FormularioCategoriaViewModel formularioVM)
    {
        return new Categoria(formularioVM.Titulo);
    }

    public static DetalhesCategoriaViewModel ParaDetalhesVM(this Categoria categoria)
    {
        return new DetalhesCategoriaViewModel(
                categoria.Id,
                categoria.Titulo,
                categoria.Despesas?.Count ?? 0,
                categoria.Despesas?.Select(d => d.Descricao).ToList() ?? new()
        );
    }
}