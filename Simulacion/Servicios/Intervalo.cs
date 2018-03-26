using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class Intervalo
    {
        public double LimiteSuperior { set; get; }
        public double LimiteInferior { set; get; }
        public int Observarciones { set; get; }

        public Intervalo(double l_inf, double l_sup, int observaciones)
        {
            this.LimiteSuperior = l_sup;
            this.LimiteInferior = l_inf;
            this.Observarciones = observaciones;
        }


    }
}
