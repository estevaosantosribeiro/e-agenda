using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace EAgenda.Infraestrutura.Arquivos.ModuloContato;

public class RepositorioContatoEmArquivo : RepositorioBaseEmArquivo <Contato> , IRepositorioContato
{
    public RepositorioContatoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Contato> ObterRegistros()
    {
        return contexto.Contatos;
    }
}
