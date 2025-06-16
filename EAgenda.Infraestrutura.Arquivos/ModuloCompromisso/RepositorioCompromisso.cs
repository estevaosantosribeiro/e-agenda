using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Infraestrutura.Arquivos.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBaseEmArquivo<Compromisso>
    {
        public RepositorioCompromisso(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Compromisso> ObterRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
