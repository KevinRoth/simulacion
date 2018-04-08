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
        public Generado Generado { get; set; }
        public double Semilla { get; set; }
        public double ProximaSemilla { get; set; }

        public GeneradorMultiplicativo()
        {
            Generado = new Generado();
        }

        public void CalcularA(double k)
        {
            A = 3 + 8 * k;
        }

        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        public Generado generarAleatorio()
        {
            ProximaSemilla = (((A * Semilla)) % M);   // = [(a.xi + c) mod m]

            Generado.NumAleatorio = ProximaSemilla / M;

            Semilla = ProximaSemilla;

            return Generado;
        }
    }
}
