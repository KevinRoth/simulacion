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
        public Vehiculo VehiculoActual { get; set; }
        public string Nombre { get; set; }

        public Transbordador()
        {
        }

        public Transbordador(string ubicacion, Uniforme distribucionCargaAutos,
            Uniforme distribucionCargaCamiones, int capacidad, string nombre)
        {
            Ubicacion = ubicacion;
            DistribucionCargaAutos = distribucionCargaAutos;
            DistribucionCargaCamiones = distribucionCargaCamiones;
            Capacidad = capacidad;
            Estado = "Libre";
            Vehiculos = new List<Vehiculo>();
            Nombre = nombre;
        }

        public Transbordador(double random, DateTime tiempoentrecargas, DateTime proximacarga, Vehiculo vehiculo)
        {
            RandomCargas = random;
            TiempoEntreCargas = tiempoentrecargas;
            ProximaCarga = proximacarga;
            VehiculoActual = vehiculo;
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        public List<Vehiculo> CargarVehiculo(List<Vehiculo> colaVehiculos, DateTime reloj)
        {
            Random random = new Random();
            var vehiculo = colaVehiculos.First();

            if (vehiculo.TipoVehiculo == "Auto")
            {
                if (reloj < colaVehiculos.First().ProximaLlegada)
                {
                    return colaVehiculos;
                }

                if (Capacidad == 0)
                {
                    Estado = "Para irse a la mocha";
                    return colaVehiculos;
                }

                if (ProximaCarga == new DateTime())
                {
                    Capacidad--;
                    RandomCargas = random.NextDouble();
                    DistribucionCargaAutos.GenerarVariableAleatoria(RandomCargas);

                    var generado = DistribucionCargaAutos.GenerarVariableAleatoria(RandomCargas);
                    TiempoEntreCargas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaCarga = TiempoEntreCargas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaCarga = proximaCarga;
                    Estado = "Ocupado";

                    vehiculo.TiempoCarga = TiempoEntreCargas;
                    vehiculo.Estado = $"Cargando en {Nombre}";

                    Vehiculos.Add(vehiculo);
                    TransbordadorActual = new Transbordador(RandomCargas, TiempoEntreCargas, ProximaCarga, vehiculo);

                    colaVehiculos.Remove(colaVehiculos.First());
                }

                return colaVehiculos;
            }
            else
            {
                if (reloj < colaVehiculos.First().ProximaLlegada)
                {
                    return colaVehiculos;
                }

                if (Capacidad <= 1)
                {
                    Estado = "Para irse a la mocha";
                    return colaVehiculos;
                }

                if (ProximaCarga == new DateTime())
                {
                    Capacidad -= 2;
                    RandomCargas = random.NextDouble();
                    DistribucionCargaAutos.GenerarVariableAleatoria(RandomCargas);

                    var generado = DistribucionCargaCamiones.GenerarVariableAleatoria(RandomCargas);
                    TiempoEntreCargas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaCarga = TiempoEntreCargas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaCarga = proximaCarga;
                    Estado = "Ocupado";

                    vehiculo.TiempoCarga = TiempoEntreCargas;
                    vehiculo.Estado = $"Cargando en {Nombre}";

                    Vehiculos.Add(vehiculo);
                    TransbordadorActual = new Transbordador(RandomCargas, TiempoEntreCargas, ProximaCarga, vehiculo);

                    colaVehiculos.Remove(colaVehiculos.First());
                }

                return colaVehiculos;
            }
        }
    }
}