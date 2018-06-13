using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos_Colas_2
{
    public class Vehiculo
    {
        public string TipoVehiculo { get; set; }
        public DateTime ProximaLlegada { get; set; }
        public DateTime TiempoCarga { get; set; }
        public string Estado { get; set; }
        public int Tamanio { get; set; }

        public Vehiculo()
        {
        }

        public Vehiculo(string tipo, DateTime proximaLlegada)
        {
            TipoVehiculo = tipo;
            Estado = "En cola";
            ProximaLlegada = proximaLlegada;

            if (TipoVehiculo == "Camion")
            {
                Tamanio = 2;
            }
            else
            {
                Tamanio = 1;
            }
        }

    
    }
}