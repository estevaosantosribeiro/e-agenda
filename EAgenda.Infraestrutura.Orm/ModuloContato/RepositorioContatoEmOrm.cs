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
        throw new NotImplementedException();
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        throw new NotImplementedException();
    }

    public Contato? SelecionarRegistroPorId(Guid idRegistro)
    {
        throw new NotImplementedException();
    }

    public List<Contato> SelecionarRegistros()
    {
        return contexto.Contatos.ToList();
    }
}
