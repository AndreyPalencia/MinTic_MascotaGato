using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia.AppRepositorio;

namespace CuidadoEnCasa.App.Persistencia.AppRepositorio
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;
        /// <summary>
        /// </summary>
        //<param name="appContext"> </param>
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }
             //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////CRUD Propietario///////////////////////////
        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        

        void IRepositorioPropietario.DelectePropietario(int IdPropietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == IdPropietario);
            if (propietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int IdPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.Id == IdPropietario);
        }



        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == propietario.Id);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Nombre = propietario.Nombre;
                propietarioEncontrado.Apellido = propietario.Apellido;
                propietarioEncontrado.Direccion = propietario.Direccion;
                propietarioEncontrado.Telefono = propietario.Telefono;
                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }

        //

    }
}