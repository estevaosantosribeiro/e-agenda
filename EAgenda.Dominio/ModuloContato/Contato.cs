using EAgenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Dominio.ModuloContato
{
    public class Contato : EntidadeBase<Contato>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }

        public Contato(string nome, string email, string telefone, string cargo, string empresa)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
            Empresa = empresa;

        }

        public override void AtualizarRegistro(Contato registroEditado)
        {
            Nome = registroEditado.Nome;
            Nome = registroEditado.Email;
            Nome = registroEditado.Telefone;
            Nome = registroEditado.Cargo;
            Nome = registroEditado.Empresa;
        }
    }
}
