using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.Infraestrutura.Orm.ModuloContato;

public class RepositorioContatoEmOrm : IRepositorioContato
{
    private readonly EAgendaDbContext contexto;
    
    public RepositorioContatoEmOrm(EAgendaDbContext contexto)
    {
        this.contexto = contexto;
    }
    public void CadastrarRegistro(Contato registro)
    {
        contexto.Contatos.Add(registro);
    }

    public bool EditarRegistro(Guid idRegistro, Contato registroEditado)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null )
            return false;

        registroSelecionado.AtualizarRegistro(registroEditado);

        return true;
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null )
            return false;

        contexto.Contatos.Remove(registroSelecionado);

        return true;
    }

    public Contato? SelecionarRegistroPorId(Guid idRegistro)
    {
        return contexto.Contatos.FirstOrDefault(x => x.Id.Equals(idRegistro));
    }

    public List<Contato> SelecionarRegistros()
    {
        return contexto.Contatos.ToList();
    }
}
