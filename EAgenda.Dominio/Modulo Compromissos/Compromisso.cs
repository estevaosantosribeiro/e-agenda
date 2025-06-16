using EAgenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Dominio.Modulo_Compromissos
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string Assunto { get; set; }
        public DateTime DataDeOcorrencia { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeTermino { get; set; }
        public string TipoDeOcorrido { get; set; }


        public override void AtualizarRegistro(Compromisso registroEditado)
        {
            Assunto = registroEditado.TipoDeOcorrido;
            DataDeOcorrencia = registroEditado.DataDeOcorrencia;
            HoraDeInicio = registroEditado.HoraDeInicio;
            HoraDeTermino = registroEditado.HoraDeTermino;
            TipoDeOcorrido = registroEditado.TipoDeOcorrido;
                
        }
    }
}
