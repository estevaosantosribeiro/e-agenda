using EAgenda.Dominio.ModuloContato;
using EAgenda.Infraestrutura.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Infraestrutura.Arquivos.ModuloContato
{
    public class RepositorioContatoEmArquivo : RepositorioBaseEmArquivo <Contato>
    {
        protected override List<Contato> ObterRegistros()
        {
            return contexto.
        }
    }
}
