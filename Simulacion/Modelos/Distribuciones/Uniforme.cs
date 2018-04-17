using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos.Distribuciones
{
    public class Uniforme : Distribucion
    {
        public double A { get; set; }
        public double B { get; set; }
        public Generado Generado { get; protected set; }
        public GeneradorLenguaje Generador { get; protected set; }

        public Uniforme()
        {
            Generado = new Generado();
            Generador = new GeneradorLenguaje();

        }

        /// <summary>
        /// Metodo que permite conocer si B es mayor a A
        /// Devuelve true si B > A
        /// </summary>
        /// <returns></returns>
        public bool CompararAB()
        {
            return B > A;
        }

        public Generado GenerarVariableAleatoria(int i)
        {
            var x = A + Generador.GenerarAleatorio(i).NumAleatorio * (B - A);

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;

            return Generado;
        }
    }
}
