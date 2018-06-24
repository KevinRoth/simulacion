using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Montecarlo.TablaDistribucion;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion.Modelos_Colas_2
{
    public class Transbordador
    {
        public string Ubicacion { get; set; }
        public Uniforme DistribucionCargaAutos { get; set; }
        public Uniforme DistribucionCargaCamiones { get; set; }
        public Uniforme DistribucionCruceAgua { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public double RandomCargas { get; set; }
        public DateTime TiempoEntreCargas { get; set; }
        public DateTime ProximaCarga { get; set; }
        public double RandomCruceAgua { get; set; }
        public DateTime TiempoCruce { get; set; }
        public DateTime ProximaLlegadaTierra { get; set; }
        public Transbordador TransbordadorActual { get; set; }
        public Vehiculo VehiculoActual { get; set; }
        public string Nombre { get; set; }
        public DateTime Descarga { get; set; }
        public DateTime ProximaDescarga { get; set; }
        public int Mantenimiento { get; set; }
        public DateTime ProximoFinMantenimiento { get; set; }
        public double RandomInterrupcion { get; set; }
        public DateTime TiempoInterrupcion { get; set; }
        public DateTime ProximoFinInterrupcion { get; set; }
        public DistribucionAleatoria DistribucionInterrupciones50 { get; set; }
        public DistribucionAleatoria DistribucionInterrupciones70 { get; set; }
        public DistribucionAleatoria DistribucionInterrupciones100 { get; set; }

        public Transbordador()
        {
        }

        public Transbordador(string ubicacion, Uniforme distribucionCargaAutos,
            Uniforme distribucionCargaCamiones, int capacidad, string nombre, Uniforme distribucionCruceAgua,
            int mantenimiento)
        {
            Ubicacion = ubicacion;
            DistribucionCargaAutos = distribucionCargaAutos;
            DistribucionCargaCamiones = distribucionCargaCamiones;
            Capacidad = capacidad;
            Estado = "Libre";
            Vehiculos = new List<Vehiculo>();
            Nombre = nombre;
            DistribucionCruceAgua = distribucionCruceAgua;
            Mantenimiento = mantenimiento;

            DistribucionInterrupciones50 = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(273, 0.20),
                new Probabilidad(0, 0.80)
            });

            DistribucionInterrupciones70 = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(312, 0.30),
                new Probabilidad(0, 0.70)
            });

            DistribucionInterrupciones100 = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(364, 0.50),
                new Probabilidad(0, 0.50)
            });
        }

        public Transbordador(double random, DateTime tiempoentrecargas, DateTime proximacarga, Vehiculo vehiculo)
        {
            RandomCargas = random;
            TiempoEntreCargas = tiempoentrecargas;
            ProximaCarga = proximacarga;
            VehiculoActual = vehiculo;
        }

        public void ObtenerInterrupcion(DateTime reloj, int numero, int dias)
        {
            Random random = new Random();
            RandomInterrupcion = random.NextDouble();

            if (numero == 50)
            {
                var tiempoInterrupcion = DistribucionInterrupciones50.ObtenerValor(RandomInterrupcion);
                TiempoInterrupcion = dias > 1 ? DateTime.Today.AddDays(dias -1 ).AddMinutes(tiempoInterrupcion) :
                    DateTime.Today.AddMinutes(tiempoInterrupcion);

                ProximoFinInterrupcion = TiempoInterrupcion.AddMinutes(DateTimeConverter.EnMinutos(reloj));
            }
            else if (numero == 70)
            {
                var tiempoInterrupcion = DistribucionInterrupciones70.ObtenerValor(RandomInterrupcion);
                TiempoInterrupcion = dias > 1 ? DateTime.Today.AddDays(dias - 1).AddMinutes(tiempoInterrupcion) :
                    DateTime.Today.AddMinutes(tiempoInterrupcion);

                ProximoFinInterrupcion = TiempoInterrupcion.AddMinutes(DateTimeConverter.EnMinutos(reloj));
            }
            else if (numero == 100)
            {
                var tiempoInterrupcion = DistribucionInterrupciones100.ObtenerValor(RandomInterrupcion);
                TiempoInterrupcion = dias > 1 ? DateTime.Today.AddDays(dias - 1).AddMinutes(tiempoInterrupcion) :
                    DateTime.Today.AddMinutes(tiempoInterrupcion);

                ProximoFinInterrupcion = TiempoInterrupcion.AddMinutes(DateTimeConverter.EnMinutos(reloj));
            }
          
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        public bool EstaDescargando()
        {
            return Estado.Equals("Descargando");
        }

        public bool EstaOcupado()
        {
            return Estado.Equals("Ocupado");
        }

        public bool EstaCruzandoAgua()
        {
            return Estado.Equals("Cruzando agua");
        }

        public bool EstaParaMantenimiento()
        {
            return Mantenimiento == 0;
        }

        public void ObtenerCruceAgua(DateTime reloj)
        {
            if (ProximaLlegadaTierra == new DateTime())
            {
                Random random = new Random();
                RandomCruceAgua = random.NextDouble();

                var generado = DistribucionCruceAgua.GenerarVariableAleatoria(RandomCruceAgua);
                TiempoCruce = DateTime.Today.AddMinutes(generado.NumAleatorio);
                ProximaLlegadaTierra = TiempoCruce.AddMinutes(DateTimeConverter.EnMinutos(reloj));

                Estado = "Cruzando agua";
            }
        }

        public DateTime? DescargarVehiculo(DateTime reloj)
        {
            if (Vehiculos.Count == 0)
            {
                Estado = "Libre";
                return reloj.AddHours(1);
            }
            else
            {
                if (ProximaDescarga == new DateTime())
                {
                    var vehiculo = Vehiculos.First();

                    if (vehiculo.TipoVehiculo == "Auto")
                    {
                        Capacidad++;
                    }
                    else
                    {
                        Capacidad += 2;
                    }

                    var tiempoDescarga = DateTimeConverter.EnMinutos(vehiculo.TiempoCarga) / 2.0;
                    Descarga = DateTime.Today.AddMinutes(tiempoDescarga);
                    ProximaDescarga = Descarga.AddMinutes(DateTimeConverter.EnMinutos(reloj));

                    Vehiculos.Remove(vehiculo);
                }

                return null;
            }
        }

        public List<Vehiculo> CargarVehiculo(List<Vehiculo> colaVehiculos, DateTime reloj)
        {
            Random random = new Random();
            var vehiculo = colaVehiculos.First();

            if (vehiculo.TipoVehiculo == "Auto")
            {
              

                if (Capacidad == 0)
                {
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
               

                if (Capacidad <= 1)
                {
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