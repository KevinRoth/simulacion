using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos
{
    public class Subintervalos
    {
        public Subintervalos(double limiteInferior, double limiteSuperior)
        {
            this.LimiteInferior = limiteInferior;
            this.LimiteSuperior = limiteSuperior;
        }

        public int CantidadObservaciones { get; set; }

        public double LimiteSuperior { get; set; }

        public double LimiteInferior { get; set; }
    }
}

