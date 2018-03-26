using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class GeneradorMultiplicativo
    {
        public double A { set; get; }
        public double C { set; get; }
        public double M { set; get; }
        public GeneradosMultiplicativo Generado { get; set; }

        public GeneradorMultiplicativo()
        {
            Generado = new GeneradosMultiplicativo();
        }
        
        public void CalcularA(double k)
        {
            A = 1 + 4 * k;
        }

        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        public GeneradosMultiplicativo generarAleatorio()
        {
            Generado.ProximaSemilla = (((A * Generado.Semilla) + C) % M);   // = [(a.xi + c) mod m]

            Generado.NumAleatorio = Generado.ProximaSemilla / M;

            Generado.Semilla = Generado.ProximaSemilla;

            return Generado;
        }
    }
}
