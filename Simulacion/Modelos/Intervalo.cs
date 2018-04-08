namespace Simulacion.Modelos
{
    public class Intervalo
    {
        public Intervalo(double limiteInferior, double limiteSuperior)
        {
            this.LimiteInferior = limiteInferior;
            this.LimiteSuperior = limiteSuperior;
        }

        public int CantidadObservaciones { get; set; }

        public double LimiteSuperior { get; set; }

        public double LimiteInferior { get; set; }
    }
}

