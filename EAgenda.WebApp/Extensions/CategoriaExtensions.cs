using EAgenda.Dominio.ModuloCategoria;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class CategoriaExtensions
{
    public static Categoria ParaEntidade(this FormularioCategoriaViewModel formularioVM)
    {
        return new Categoria(formularioVM.Titulo, formularioVM.Despesas);
    }

    public static DetalhesCategoriaViewModel ParaDetalhesVM(this Categoria garcom)
    {
        return new DetalhesCategoriaViewModel(
                garcom.Id,
                garcom.Titulo,
                garcom.Despesas
        );
    }
}