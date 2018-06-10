using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion.Modelos_Colas_2
{
    public class Transbordador
    {
        public string Ubicacion { get; set; }
        public Uniforme DistribucionCargaAutos { get; set; }
        public Uniforme DistribucionCargaCamiones { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public double RandomCargas { get; set; }
        public DateTime TiempoEntreCargas { get; set; }
        public DateTime ProximaCarga { get; set; }
        public Transbordador TransbordadorActual { get; set; }

        public Transbordador()
        {

        }

        public Transbordador(string ubicacion, Uniforme distribucionCargaAutos,
            Uniforme distribucionCargaCamiones, int capacidad)
        {
            Ubicacion = ubicacion;
            DistribucionCargaAutos = distribucionCargaAutos;
            DistribucionCargaCamiones = distribucionCargaCamiones;
            Capacidad = capacidad;
            Estado = "Libre";
            Vehiculos = new List<Vehiculo>();
        }

        public Transbordador(double random, DateTime tiempoentrecargas, DateTime proximacarga)
        {
            RandomCargas = random;
            TiempoEntreCargas = tiempoentrecargas;
            ProximaCarga = proximacarga;
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        public Transbordador CargarVehiculo(Vehiculo vehiculo, DateTime reloj)
        {
            Random random = new Random();
            if (vehiculo.TipoVehiculo == "Auto")
            {
                Capacidad--;
                RandomCargas = random.NextDouble();
                DistribucionCargaAutos.GenerarVariableAleatoria(RandomCargas);

                var generado = DistribucionCargaAutos.GenerarVariableAleatoria(RandomCargas);
                TiempoEntreCargas= new DateTime().AddMinutes(generado.NumAleatorio);
                var proximaCarga = TiempoEntreCargas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                ProximaCarga = proximaCarga;
                vehiculo.TiempoCarga = TiempoEntreCargas;
                TransbordadorActual = new Transbordador(RandomCargas, TiempoEntreCargas, ProximaCarga);
            }
            else
            {

            }
        }


    }
}
