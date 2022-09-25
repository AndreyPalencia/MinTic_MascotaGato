using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia.AppRepositorio;

namespace CuidadoEnCasa.App.Persistencia.AppRepositorio
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;
        /// <summary>
        /// </summary>
        //<param name="appContext"> </param>
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }
        ////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////CRUD Veterinario//////////////////////////////////////////
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicianado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicianado.Entity;
        }

        void IRepositorioVeterinario.DelecteVeterinario(int IdVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(ve => ve.Id == IdVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int IdVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(ve => ve.Id == IdVeterinario);
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(ve => ve.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellido = veterinario.Apellido;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                //veterinarioEncontrado.TarjeProfecional = veterinario.TarjeProfecional;

                _appContext.SaveChanges();

            }
            return veterinarioEncontrado;
        }

        //
        

    }
}