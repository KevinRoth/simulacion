using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Modelos
{
    public class GeneradorMixto 
    {
        public double A { set; get; }
        public double C { set; get; }
        public double M { set; get; }
        public Generado Generado { get; set; }
        public double ProximaSemilla { get; set; }
        public double Semilla { get; set; }

        public GeneradorMixto()
        {
            Generado = new Generado();
        }
        
        public void CalcularA(double k)
        {
            A = 1 + 4 * k;
        }

        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        public Generado GenerarAleatorio(int i)
        {
            ProximaSemilla = (((A * Semilla) + C) % M);   // = [(a.xi + c) mod m]

            Semilla = ProximaSemilla;

            Generado.NumAleatorio = ProximaSemilla / M;

            Generado.Iteracion = i;

            return Generado;
        }

        public List<Generado> GenerarAleatorios(int cantidad)
        {
         var lista = new List<Generado>();

            for (int i = 0; i < cantidad; i++)
            {
                var generado = GenerarAleatorio(i);

                lista.Add(generado);

                generado = null;
            }

            return lista;
        }


    }
}
