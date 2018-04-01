using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos
{
    public class Subintervalos
    {
        public Subintervalos(float limiteInferior, float limiteSuperior)
        {
            this.LimiteInferior = limiteInferior;
            this.LimiteSuperior = limiteSuperior;
        }

        public int CantidadObservaciones { get; set; }

        public float LimiteSuperior { get; set; }

        public float LimiteInferior { get; set; }
    }
}

