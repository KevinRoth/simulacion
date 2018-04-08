using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos
{
    public class Generado
    {
        public int Iteracion { get; set; }
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
