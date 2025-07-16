using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloCompromissos;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.Infraestrutura.Orm.ModuloCompromisso;

public class RepositorioCompromissoEmOrm : RepositorioBaseEmOrm<Compromisso>, IRepositorioCompromisso
{
    public RepositorioCompromissoEmOrm(EAgendaDbContext contexto) : base(contexto)
    {
    }
}
