using EAgenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Dominio.Modulo_Compromissos
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string Assunto { get; set; }
        public DateOnly DataDeOcorrencia { get; set; }
        public TimeSpan HoraDeInicio { get; set; }
        public TimeSpan HoraDeTermino { get; set; }
        public string TipoDeOcorrido { get; set; }

        public Compromisso(string assunto,DateOnly dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoDeOcorrido)
        {
            Assunto = assunto;
            DataDeOcorrencia = dataDeOcorrencia;
            HoraDeInicio = horaDeInicio;
            HoraDeTermino = horaDeTermino;
            TipoDeOcorrido = tipoDeOcorrido;
        }

        public override void AtualizarRegistro(Compromisso registroEditado)
        {
            Assunto = registroEditado.Assunto;
            DataDeOcorrencia = registroEditado.DataDeOcorrencia;
            HoraDeInicio = registroEditado.HoraDeInicio;
            HoraDeTermino = registroEditado.HoraDeTermino;
            TipoDeOcorrido = registroEditado.TipoDeOcorrido;
                
        }
    }
}
