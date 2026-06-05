using CasosDeUso.InterfacesCasosDeUso.ICUObservacion;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUsoObservacion
{
    public class CUAltaObservacion : ICUAltaObservacion
    {
        public IRepositorioObservacion RepoObservacion { get; set; }
        public IRepositorioPrestamo RepoPrestamo { get; set; }
        public IRepositorioCuerpoCeleste RepoCC {  get; set; }
        public CUAltaObservacion(IRepositorioObservacion repoO, IRepositorioPrestamo repoPrestamo, IRepositorioCuerpoCeleste repoCC)
        {
            RepoObservacion = repoO;
            RepoPrestamo = repoPrestamo;
            RepoCC = repoCC;
        }
        public void Ejecutar (int idPrestamo, int idCuerpo, DateTime fecha) //tambien recibe la evaluacion de gemini
        {
            Observacion obs = new Observacion();
            Prestamo pBusacado = RepoPrestamo.FindById(idPrestamo);
            CuerpoCeleste ccBusacado = RepoCC.FindById(idCuerpo);
            obs.Prestamo = pBusacado;
            obs.CuerpoCeleste = ccBusacado;
            if(pBusacado.Inicio <= fecha && pBusacado.Fin >= fecha)
            {
                RepoObservacion.Add(obs);
            }


        }
    }
}
