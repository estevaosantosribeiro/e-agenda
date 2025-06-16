using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace EAgenda.Infraestrutura.Arquivos.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Categoria> ObterRegistros()
    {
        return contexto.Categorias;
    }
}
