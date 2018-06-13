using System;

namespace Colas
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
