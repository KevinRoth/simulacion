using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos
{
    public class Generado
    {
        public double Semilla { set; get; }
        public double ProximaSemilla { set; get; }
        public double NumAleatorio { set; get; }

        public Generado(double a)
        {
            NumAleatorio = a;
        }

        public Generado()
        {

        }
    }
}
