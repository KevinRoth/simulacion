using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos_Colas_2
{
    public class Vehiculo
    {
        public string TipoVehiculo { get; protected set; }
        public decimal TiempoCarga { get; protected set; }

        public Vehiculo()
        {

        }

        public Vehiculo(string tipo)
        {
            TipoVehiculo = tipo;
        }

        public Vehiculo(string tipo, decimal tiempoCarga)
        {
            TipoVehiculo = tipo;
            TiempoCarga = tiempoCarga;
        }
    }
}
