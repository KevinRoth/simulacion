using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion.Modelos_Colas_2
{
    public class Llegada
    {
        public Uniforme DistribucionLlegadasAutosContinente { get; set; }
        public Uniforme DistribucionLlegadasAutosIsla { get; set; }
        public Uniforme DistribucionLlegadasCamionesContinente { get; set; }
        public Uniforme DistribucionLlegadasCamionesIsla { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public double RandomLlegada { get; set; }
        public DateTime TiempoEntreLlegadas { get; set; }
        public DateTime ProximaLlegada { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public Llegada LlegadaActual { get; set; }

        public Llegada(Uniforme distribucion, string tipoVehiculo, string ubicacion)
        {
            if (tipoVehiculo == "Auto" && ubicacion == "Continente")
            {
                DistribucionLlegadasAutosContinente = distribucion;
            }

            if (tipoVehiculo == "Auto" && ubicacion == "Isla")
            {
                DistribucionLlegadasAutosIsla = distribucion;
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Continente")
            {
                DistribucionLlegadasCamionesContinente = distribucion;
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Isla")
            {
                DistribucionLlegadasCamionesIsla = distribucion;
            }
        }

        public Llegada(Uniforme distribucionLlegadasAutosContinente, Uniforme distribucionLlegadasAutosIsla,
            Uniforme distribucionLlegadasCamionesContinente, Uniforme distribucionLlegadasCamionesIsla, DateTime inicio,
            DateTime fin)
        {
            DistribucionLlegadasAutosContinente = distribucionLlegadasAutosContinente;
            DistribucionLlegadasAutosIsla = distribucionLlegadasAutosIsla;
            DistribucionLlegadasCamionesContinente = distribucionLlegadasCamionesContinente;
            DistribucionLlegadasCamionesIsla = distribucionLlegadasCamionesIsla;
            HoraInicio = inicio;
            HoraFin = fin;

            TiempoEntreLlegadas = DateTime.Today;
            ProximaLlegada = DateTime.Today;
        }

        public Llegada(double random, DateTime tiempoentrellegadas, DateTime proximallegada, Vehiculo vehiculo)
        {
            RandomLlegada = random;
            TiempoEntreLlegadas = tiempoentrellegadas;
            ProximaLlegada = proximallegada;
            Vehiculo = vehiculo;
        }

        public List<Vehiculo> ObtenerLlegadaVehiculo(string tipoVehiculo, string ubicacion, DateTime reloj,
            double random, List<Vehiculo> cola)
        {
            if (tipoVehiculo == "Auto" && ubicacion == "Continente")
            {
                if (ProximaLlegada == new DateTime())
                {
                    RandomLlegada = random;
                    var generado = DistribucionLlegadasAutosContinente.GenerarVariableAleatoria(RandomLlegada);
                    TiempoEntreLlegadas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaLlegada = proximaLlegada;
                    Vehiculo = new Vehiculo("Auto", ProximaLlegada);
                    LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
                    cola.Add(Vehiculo);
                }

                return cola;
            }

            if (tipoVehiculo == "Auto" && ubicacion == "Isla")
            {
                if (ProximaLlegada == new DateTime())
                {
                    RandomLlegada = random;
                    var generado = DistribucionLlegadasAutosIsla.GenerarVariableAleatoria(RandomLlegada);

                    TiempoEntreLlegadas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaLlegada = proximaLlegada;
                    Vehiculo = new Vehiculo("Auto", ProximaLlegada);

                    var llegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);

                    LlegadaActual = llegadaActual;

                    cola.Add(Vehiculo);
                }

                return cola;
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Continente")
            {
                if (ProximaLlegada == new DateTime())
                {
                    RandomLlegada = random;
                    var generado = DistribucionLlegadasCamionesContinente.GenerarVariableAleatoria(RandomLlegada);
                    TiempoEntreLlegadas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaLlegada = proximaLlegada;
                    Vehiculo = new Vehiculo("Camion", ProximaLlegada);

                    LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);

                    cola.Add(Vehiculo);
                }

                return cola;
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Isla")
            {
                if (ProximaLlegada == new DateTime())
                {
                    RandomLlegada = random;
                    var generado = DistribucionLlegadasCamionesIsla.GenerarVariableAleatoria(RandomLlegada);
                    TiempoEntreLlegadas = DateTime.Today.AddMinutes(generado.NumAleatorio);
                    var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                    ProximaLlegada = proximaLlegada;
                    Vehiculo = new Vehiculo("Camion", ProximaLlegada);

                    LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
                }

                return cola;
            }

            return cola;
        }

        public void SetDistribucionLlegadaAutosContinente(Uniforme distribucion)
        {
            DistribucionLlegadasAutosContinente = distribucion;
        }

        public void SetDistribucionLlegadaCamionesContinente(Uniforme distribucion)
        {
            DistribucionLlegadasCamionesContinente = distribucion;
        }

        public Llegada ObtenerLlegada()
        {
            return this;
        }

        public string ObtenerEvento()
        {
            return "Llegada";
        }

        public bool EstaAbierto(DateTime reloj)
        {
            return DateTimeConverter.EnHoras(reloj) >= DateTimeConverter.EnHoras(HoraInicio);
        }

        public bool EstaCerrado(DateTime reloj)
        {
            return DateTimeConverter.EnHoras(reloj) <= DateTimeConverter.EnHoras(HoraFin);
        }
    }
}