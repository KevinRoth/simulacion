using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos_Colas_2
{
    public class Evento
    {
        public Evento(string nombre, DateTime? hora)
        {
            Nombre = nombre;
            Hora = hora;
        }

        public string Nombre { get; protected set; }
        public DateTime? Hora { get; protected set; }
    }
}
