using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.Infraestrutura.Orm.ModuloCategoria;

public class RepositorioCategoriaEmOrm : RepositorioBaseEmOrm<Categoria>
{
    public RepositorioCategoriaEmOrm(EAgendaDbContext contexto) : base(contexto)
    {
    }
}
