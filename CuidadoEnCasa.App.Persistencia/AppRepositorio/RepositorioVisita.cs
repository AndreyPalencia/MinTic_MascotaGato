using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia.AppRepositorio;

namespace CuidadoEnCasa.App.Persistencia.AppRepositorio
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;
        /// <summary>
        /// </summary>
        //<param name="appContext"> </param>
        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        //////////////////////////////////CRUD Visita////////////////////////////////
        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            var visitaAdicionada = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionada.Entity;
        }

        Visita IRepositorioVisita.AsignarMascota_Gato(int IdVisita, int IdMascota_Gato)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(p => p.Id == IdVisita);
            if (visitaEncontrada != null)
            {
                var mascota_GatoEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota_Gato );
                if (mascota_GatoEncontrada != null)
                {
                    visitaEncontrada.Mascota_Gato = mascota_GatoEncontrada;
                    _appContext.SaveChanges();
                }
                return visitaEncontrada;
            }
            return null;
        }

        Visita IRepositorioVisita.AsignarVeteniarrio(int IdVisita, int IdVeterinario)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(p => p.Id == IdVisita);
            if (visitaEncontrada != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(m => m.Id == IdVeterinario );
                if (veterinarioEncontrado != null)
                {
                    visitaEncontrada.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return visitaEncontrada;
            }
            return null;
        }

        void IRepositorioVisita.DelecteVisita(int IdVisita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(v => v.Id == IdVisita);
            if (visitaEncontrada == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrada);
            _appContext.SaveChanges();
        }
        void IRepositorioVisita.DelecteVisita(DateTime FechaVisita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(v => v.FechaVisita == FechaVisita);
            if (visitaEncontrada == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrada);
            _appContext.SaveChanges();
        }

        Visita IRepositorioVisita.GetVisita(int IdVisita)
        {
            return _appContext.Visitas.FirstOrDefault(v => v.Id == IdVisita);
        }

        Visita IRepositorioVisita.GetVisitaFecha(DateTime FechaVisita)
        {
            return _appContext.Visitas.FirstOrDefault(v => v.FechaVisita == FechaVisita);

        }
        Visita IRepositorioVisita.UpdateVisita(Visita visita)
        {
            var visitaEncontrada = _appContext.Visitas.FirstOrDefault(v => v.Id == visita.Id);
            if (visitaEncontrada != null)
            {
                visitaEncontrada.FechaVisita = visita.FechaVisita;
                visitaEncontrada.Veterinario = visita.Veterinario;
                visitaEncontrada.Mascota_Gato = visita.Mascota_Gato;
                _appContext.SaveChanges();

            }
            return visitaEncontrada;
        }

   
    }
}