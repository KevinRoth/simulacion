using System;
using System.Collections.Generic;
using System.Globalization;
using Colas;
using Montecarlo.TablaDistribucion;
using Simulacion.Modelos;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion.Modelos_Colas
{
    public class Vehiculo
    {
        public string RandomTipoVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string RandomLlegadaVehiculo { get; set; }
        public DateTime? HoraLlegada { get; set; }
        public DateTime? ProximaHoraLlegada { get; set; }
        private DistribucionAleatoria _demoraVehiculo { get; set; }

        public Vehiculo()
        {

        }

        public Vehiculo ObtenerLlegadaVehiculo(double a, double b, DateTime reloj)
        {
            var randomTipoVehiculo = new Random();

            if (randomTipoVehiculo.NextDouble() > 0.50)//es camion
            {
                var uniforme = new Uniforme(a, b).GenerarVariableAleatoria();
                var h = new DateTime(uniforme);
                var horaLlegada = DateTimeConverter.DesdeHoras(Decimal.Parse(uniforme.ToString(CultureInfo.InvariantCulture)));

                var proximaLlegada = reloj + horaLlegada;
            }
        }
    }
}
