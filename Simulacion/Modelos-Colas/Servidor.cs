using System;
using System.Diagnostics.CodeAnalysis;
using Colas.Clientes;
using Colas.Colas;
using Simulacion.Modelos.Distribuciones;

namespace Colas.Servidores
{
    public class Servidor
    {
        public Servidor(Uniforme distribucionCargaAuto, Uniforme distribucionCargaCamion,
            Uniforme distribucionCursoAgua, ICola cola, string nombre, int capacidad)
        {
            DistribucionCargaAuto = distribucionCargaAuto;
            DistribucionCargaCamion = distribucionCargaCamion;
            DistribucionCursoAgua = distribucionCursoAgua;
            Cola = cola;
            Nombre = nombre;
            Estado = "Libre";
            CantidadMaxima = capacidad;
            CantidadAtendidos = 0;
            Ubicacion = "Continente";
        }

        public bool EstaLibre()
        {
            return Estado.Equals("Libre");
        }

        public bool PuedeCruzarAgua()
        {
           var ultimaCruzada = DateTimeConverter.EnHoras(DateTime.Now) - DateTimeConverter.EnHoras(UltimaCruzadaAgua);

            if (ultimaCruzada >= 1 && EstaLibre() && Cola.Vacia())
            {
                return true;
            }

            return false;
        }

        public bool EstaOcupado()
        {
            return Estado.Equals("Ocupado");
        }

        private void ActualizarFinCarga(DateTime hora, string tipoVehiculo)
        {
            if (tipoVehiculo == "Auto")
            {
                var demora = DistribucionCargaAuto.GenerarVariableAleatoria();
                CantidadAtendidos++;
                ProximoFinCarga = hora.AddMinutes(demora);
            }
            else //camion
            {
                var demora = DistribucionCargaCamion.GenerarVariableAleatoria();
                CantidadAtendidos += 2;
                ProximoFinCarga = hora.AddMinutes(demora);
            }

        }

        public bool EstaEnMantenimiento()
        {
            return Estado.Equals("En mantenimiento");
        }

        public void LlegadaCliente(DateTime hora, Cliente cliente)
        {
            if (EstaLibre())
            {
                ClienteActual = cliente;
                cliente.ComenzarCarga(hora, Nombre);
                ActualizarFinCarga(hora, cliente.TipoCliente);
            }
            else
            {
                Cola.AgregarCliente(cliente);
            }
        }

        public void SetMantenimiento(DateTime hora)
        {
            Estado = "En mantenimiento";

            ProximoFinMantenimiento = hora.AddHours(5);
        }

        public void SetEnCursoAgua(DateTime hora)
        {
            Estado = $"{Nombre} en curso de agua";

            ProximoFinCursoAgua = hora.AddHours(DistribucionCursoAgua.GenerarVariableAleatoria());
        }

        public void SetDescargaVehiculos()
        {
            Estado = "En descarga de vehiculos";

        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public Cliente FinCarga()
        {
            var cliente = ClienteActual;

            if (Cola.Vacia())
            {
                Estado = "Libre";
                ClienteActual = null;
                ProximoFinCarga = null;
            }
            else if (EstaOcupado() || EstaEnMantenimiento())
            {
                ClienteActual = null;
                ProximoFinCarga = null;
            }
            else
            {
                ClienteActual = Cola.ProximoCliente();
                ClienteActual.ComenzarCarga(ProximoFinCarga.Value, Nombre);
                ActualizarFinCarga(ProximoFinCarga.Value, ClienteActual.TipoCliente);
            }


            return cliente;
        }

        public bool EstaLleno()
        {
            return CantidadAtendidos == CantidadMaxima;
        }


        public Uniforme DistribucionCargaAuto { get; protected set; }
        public Uniforme DistribucionCargaCamion { get; protected set; }
        public Uniforme DistribucionCursoAgua { get; protected set; }
        public string Nombre { get; protected set; }
        public DateTime? ProximoFinCarga { get; protected set; }
        public DateTime? ProximoFinMantenimiento { get; protected set; }
        public DateTime? ProximoFinCursoAgua { get; protected set; }
        public DateTime? ProximoFinDescarga { get; protected set; }
        public string Estado { get; protected set; }
        public ICola Cola { get; protected set; }
        public Cliente ClienteActual { get; protected set; }
        public int CantidadAtendidos { get; protected set; }
        public int CantidadMaxima { get; protected set; }
        public string Ubicacion { get; protected set; }
        public DateTime UltimaCruzadaAgua { get; protected set; }
    }
}
