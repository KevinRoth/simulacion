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
        public Uniforme DistribucionLlegadasAutosIsla{ get; set; }
        public Uniforme DistribucionLlegadasCamionesContinente { get; set; }
        public Uniforme DistribucionLlegadasCamionesIsla { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public double RandomLlegada { get; set; }
        public DateTime TiempoEntreLlegadas { get; set; }
        public DateTime ProximaLlegada { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin{ get; set; }


        public Llegada(Uniforme distribucionLlegadasAutosContinente, Uniforme distribucionLlegadasAutosIsla,
            Uniforme distribucionLlegadasCamionesContinente, Uniforme distribucionLlegadasCamionesIsla, DateTime inicio, DateTime fin)
        {
            DistribucionLlegadasAutosContinente = distribucionLlegadasAutosContinente;
            DistribucionLlegadasAutosIsla = distribucionLlegadasAutosIsla;
            DistribucionLlegadasCamionesContinente = distribucionLlegadasCamionesContinente;
            DistribucionLlegadasCamionesIsla = distribucionLlegadasCamionesIsla;
            HoraInicio = inicio;
            HoraFin = fin;
        }

        public Llegada(double random, DateTime tiempoentrellegadas, DateTime proximallegada, Vehiculo vehiculo)
        {
            RandomLlegada = random;
            TiempoEntreLlegadas = tiempoentrellegadas;
            ProximaLlegada = proximallegada;
            Vehiculo = vehiculo;
        }

        public Llegada ObtenerLlegadaVehiculo(string tipoVehiculo, string ubicacion, DateTime reloj)
        {

            if (tipoVehiculo == "Auto" && ubicacion == "Continente")
            {
                RandomLlegada = new Random().NextDouble();
                var generado = DistribucionLlegadasAutosContinente.GenerarVariableAleatoria(RandomLlegada);
                
                TiempoEntreLlegadas.AddMinutes(generado.NumAleatorio);
                var proximaLlegada = generado.NumAleatorio + DateTimeConverter.EnMinutos(reloj);
                ProximaLlegada.AddMinutes(proximaLlegada);
                Vehiculo = new Vehiculo("Auto");

                return new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }
            if (tipoVehiculo == "Auto" && ubicacion == "Isla")
            {
                RandomLlegada = new Random().NextDouble();
                var generado = DistribucionLlegadasAutosIsla.GenerarVariableAleatoria(RandomLlegada);
               
                TiempoEntreLlegadas.AddMinutes(generado.NumAleatorio);
                var proximaLlegada = generado.NumAleatorio + DateTimeConverter.EnMinutos(reloj);
                ProximaLlegada.AddMinutes(proximaLlegada);
                Vehiculo = new Vehiculo("Auto");

                return new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }
            if (tipoVehiculo == "Camion" && ubicacion == "Continente")
            {
                RandomLlegada = new Random().NextDouble();
                var generado = DistribucionLlegadasCamionesContinente.GenerarVariableAleatoria(RandomLlegada);
               
                TiempoEntreLlegadas.AddMinutes(generado.NumAleatorio);
                var proximaLlegada = generado.NumAleatorio + DateTimeConverter.EnMinutos(reloj);
                ProximaLlegada.AddMinutes(proximaLlegada);
                Vehiculo = new Vehiculo("Camion");

                return new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }
            if (tipoVehiculo == "Camion" && ubicacion == "Isla")
            {
                RandomLlegada = new Random().NextDouble();
                var generado = DistribucionLlegadasCamionesIsla.GenerarVariableAleatoria(RandomLlegada);
                
                TiempoEntreLlegadas.AddMinutes(generado.NumAleatorio);
                var proximaLlegada = generado.NumAleatorio + DateTimeConverter.EnMinutos(reloj);
                ProximaLlegada.AddMinutes(proximaLlegada);
                Vehiculo = new Vehiculo("Camion");

                return new Llegada(RandomLlegada, TiempoEntreLlegadas, ProximaLlegada, Vehiculo);
            }

            return null;
        }

        public Llegada ObtenerLlegada()
        {
            return this;
        }

        public string ObtenerEvento()
        {
            return $"Llegada {Vehiculo.TipoVehiculo}";  
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
