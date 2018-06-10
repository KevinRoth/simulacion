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

            TiempoEntreLlegadas = new DateTime();
            ProximaLlegada = new DateTime();
        }

        public Llegada(double random, DateTime tiempoentrellegadas, DateTime proximallegada, Vehiculo vehiculo)
        {
            RandomLlegada = random;
            TiempoEntreLlegadas = tiempoentrellegadas;
            ProximaLlegada = proximallegada;
            Vehiculo = vehiculo;
        }

        public void ObtenerLlegadaVehiculo(string tipoVehiculo, string ubicacion, DateTime reloj, double random)
        {
            if (tipoVehiculo == "Auto" && ubicacion == "Continente")
            {
                RandomLlegada = random;
                var generado = DistribucionLlegadasAutosContinente.GenerarVariableAleatoria(RandomLlegada);
                TiempoEntreLlegadas = new DateTime().AddMinutes(generado.NumAleatorio);
                var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                ProximaLlegada = proximaLlegada;
                Vehiculo = new Vehiculo("Auto");
                LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }

            if (tipoVehiculo == "Auto" && ubicacion == "Isla")
            {
                RandomLlegada = random;
                var generado = DistribucionLlegadasAutosIsla.GenerarVariableAleatoria(RandomLlegada);

                TiempoEntreLlegadas = new DateTime().AddMinutes(generado.NumAleatorio);
                var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                ProximaLlegada = proximaLlegada;
                Vehiculo = new Vehiculo("Auto");

                var llegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);

                LlegadaActual = llegadaActual;
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Continente")
            {
                RandomLlegada = random;
                var generado = DistribucionLlegadasCamionesContinente.GenerarVariableAleatoria(RandomLlegada);
                TiempoEntreLlegadas = new DateTime().AddMinutes(generado.NumAleatorio);
                var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                ProximaLlegada = proximaLlegada;
                Vehiculo = new Vehiculo("Camion");

                LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }

            if (tipoVehiculo == "Camion" && ubicacion == "Isla")
            {
                RandomLlegada = random;
                var generado = DistribucionLlegadasCamionesIsla.GenerarVariableAleatoria(RandomLlegada);
                TiempoEntreLlegadas = new DateTime().AddMinutes(generado.NumAleatorio);
                var proximaLlegada = TiempoEntreLlegadas.AddMinutes(DateTimeConverter.EnMinutos(reloj));
                ProximaLlegada = proximaLlegada;
                Vehiculo = new Vehiculo("Camion");

                LlegadaActual = new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }
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