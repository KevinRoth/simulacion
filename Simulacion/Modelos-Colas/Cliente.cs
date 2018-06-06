using System;

namespace Colas.Clientes
{
    public class Cliente
    {
        public Cliente(string nombre, string tipo)
        {
            Nombre = nombre;
            TiempoCarga = 0;
            TipoCliente = tipo;
        }

        public void Llegar(DateTime horaLlegada)
        {
            Estado = "Llegando";
            HoraLlegada = horaLlegada;
        }

        public void ComenzarCarga(DateTime horaInicioAtencion, string servidor)
        {
            HoraInicioCarga = horaInicioAtencion;
            Estado = $"En {servidor}";
        }

        public void FinalizarCarga(DateTime horaFinAtencion)
        {
            var inicioAtencion = DateTimeConverter.EnMinutos(HoraInicioCarga);
            var finAtencion = DateTimeConverter.EnMinutos(horaFinAtencion);

            TiempoCarga += finAtencion - inicioAtencion;
        }

        public void Salir(DateTime horaSalida)
        {
            var ingreso = DateTimeConverter.EnMinutos(HoraLlegada);
            var salida = DateTimeConverter.EnMinutos(horaSalida);

            TiempoEnSistema = salida - ingreso;

            if (horaSalida.Date > HoraLlegada.Date)
            {
                var dias = horaSalida.Day - HoraLlegada.Day;
                TiempoEnSistema += dias * 24 * 60;
            }

            Estado = "Saliendo";
        }

        public decimal TiempoEspera()
        {
            return TiempoEnSistema - TiempoCarga;
        }

        public decimal TiempoDescargaVehiculo()
        {
            return TiempoDescarga / 2;
        }
        
        public string Nombre { get; protected set; }
        public DateTime HoraLlegada { get; protected set; }
        public DateTime HoraInicioCarga { get; protected set; }
        public string Estado { get; protected set; }
        public decimal TiempoCarga { get; protected set; }
        public decimal TiempoDescarga { get; protected set; }
        public decimal TiempoEnSistema { get; protected set; }
        public string TipoCliente { get; protected set; }
    }
}
