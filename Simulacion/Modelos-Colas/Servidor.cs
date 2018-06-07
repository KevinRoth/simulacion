using System;
using System.Collections.Generic;
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
            VehiculosABordo = new List<Cliente>();
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

        public void ActualizarFinCarga(DateTime hora, Cliente vehiculo)
        {
            var demora = 0.0;
            if (vehiculo.TipoCliente == "Auto")
            {
                demora = DistribucionCargaAuto.GenerarVariableAleatoria();
                CantidadAtendidos++;
                ProximoFinCarga = hora.AddMinutes(demora);
            }
            else //camion
            {
                demora = DistribucionCargaCamion.GenerarVariableAleatoria();
                CantidadAtendidos += 2;
                ProximoFinCarga = hora.AddMinutes(demora);
            }

            vehiculo.TiempoCarga = demora;

            VehiculosABordo.Add(vehiculo);
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
                //  ActualizarFinCarga(hora, cliente.TipoCliente);
            }
            else
            {
                Cola.AgregarCliente(cliente);
            }
        }

        public bool EstaEnContinente()
        {
            return Ubicacion.Equals("Continente");
        }

        public void SetMantenimiento(DateTime hora)
        {
            Estado = "En mantenimiento";

            ProximoFinMantenimiento = hora.AddHours(5);
        }

        public void SetLibre()
        {
            Estado = "Libre";
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
                // ActualizarFinCarga(ProximoFinCarga.Value, ClienteActual.TipoCliente);
            }


            return cliente;
        }

        public bool EstaLleno()
        {
            return CantidadAtendidos == CantidadMaxima;
        }


        public Uniforme DistribucionCargaAuto { get; set; }
        public Uniforme DistribucionCargaCamion { get; set; }
        public Uniforme DistribucionCursoAgua { get; set; }
        public string Nombre { get; set; }
        public DateTime? ProximoFinCarga { get; set; }
        public DateTime? ProximoFinMantenimiento { get; set; }
        public DateTime? ProximoFinCursoAgua { get; set; }
        public DateTime? ProximoFinDescarga { get; set; }
        public string Estado { get; set; }
        public ICola Cola { get; set; }
        public Cliente ClienteActual { get; set; }
        public int CantidadAtendidos { get; set; }
        public int CantidadMaxima { get; set; }
        public string Ubicacion { get; set; }
        public DateTime UltimaCruzadaAgua { get; set; }
        public List<Cliente> VehiculosABordo { get; set; }
    }
}