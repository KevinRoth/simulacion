using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos
{
    public class GeneradorMixto 
    {
        public double A { set; get; }
        public double C { set; get; }
        public double M { set; get; }
        public Generados Generado { get; set; }

        public GeneradorMixto()
        {
            Generado = new Generados();
        }
        
        public void CalcularA(double k)
        {
            A = 1 + 4 * k;
        }

        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        public Generados generarAleatorio()
        {
            Generado.ProximaSemilla = (((A * Generado.Semilla) + C) % M);   // = [(a.xi + c) mod m]

            Generado.NumAleatorio = Generado.ProximaSemilla / M;

            Generado.Semilla = Generado.ProximaSemilla;

            return Generado;
        }
    }
}
