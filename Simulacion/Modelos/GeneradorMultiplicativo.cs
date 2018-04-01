using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Modelos;

namespace Simulacion.Modelos
{
    public class GeneradorMultiplicativo 
    {
        public double A { set; get; }
        public double M { set; get; }
        public Generados Generado { get; set; }

        public GeneradorMultiplicativo()
        {
            Generado = new Generados();
        }

        public void CalcularA(double k)
        {
            A = 3 + 8 * k;
        }

        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        public Generados generarAleatorio()
        {
            Generado.ProximaSemilla = (((A * Generado.Semilla)) % M);   // = [(a.xi + c) mod m]

            Generado.NumAleatorio = Generado.ProximaSemilla / M;

            Generado.Semilla = Generado.ProximaSemilla;

            return Generado;
        }
    }
}
