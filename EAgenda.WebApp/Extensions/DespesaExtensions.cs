using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class DespesaExtensions
{
    public static Despesa ParaEntidade(this FormularioDespesaViewModel formularioVM, List<Categoria> categorias)
    {
        return new Despesa(
            formularioVM.Descricao, 
            formularioVM.DataOcorrencia,
            formularioVM.Valor, 
            formularioVM.FormaPagamento,
            categorias
        );
    }

    public static DetalhesDespesaViewModel ParaDetalhesVM(this Despesa despesa)
    {
        return new DetalhesDespesaViewModel(
                despesa.Id,
                despesa.Descricao,
                despesa.DataOcorrencia ?? DateTime.Now,
                despesa.Valor,
                despesa.FormaPagamento,
                despesa.Categorias
        );
    }
}
