using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos.Distribuciones
{
    public abstract class Distribucion
    {
        public abstract double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos = 0);
    }
}
