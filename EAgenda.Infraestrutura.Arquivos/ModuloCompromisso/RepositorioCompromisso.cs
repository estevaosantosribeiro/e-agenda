using EAgenda.Dominio.Modulo_Compromissos;
using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Infraestrutura.Arquivos.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBaseEmArquivo<Compromisso> , IrepositorioCompromisso
    {
        public RepositorioCompromisso(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Compromisso> ObterRegistros()
        {
            return contexto.Compromissos;
        }
    }
}
