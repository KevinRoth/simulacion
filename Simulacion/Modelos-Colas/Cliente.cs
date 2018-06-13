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

        public string Llegar(DateTime horaLlegada)
        {
            Estado = "Llegando";
            HoraLlegada = horaLlegada;

            return ObtenerTipoVehiculo();
        }

        public string ObtenerTipoVehiculo()
        {
            var random = new Random().NextDouble();

            if (random < 0.5)
            {
                return "Auto";
            }
            else
            {
                return "Camion";
            }
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

          //  TiempoCarga += finAtencion - inicioAtencion;
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

      

        public decimal TiempoDescargaVehiculo()
        {
            return TiempoDescarga / 2;
        }
        
        public string Nombre { get;  set; }
        public DateTime HoraLlegada { get; set; }
        public DateTime HoraInicioCarga { get; set; }
        public string Estado { get; set; }
        public double TiempoCarga { get; set; }
        public decimal TiempoDescarga { get; set; }
        public decimal TiempoEnSistema { get; set; }
        public string TipoCliente { get; set; }
    }
}
