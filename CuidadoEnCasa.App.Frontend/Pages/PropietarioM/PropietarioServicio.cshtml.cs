using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CuidadoEnCasa.App.Dominio.Entidades;
using  CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia.AppRepositorio;

namespace CuidadoEnCasa.App.Frontend.Pages
{
    public class PropietarioServicioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        public IEnumerable<Propietario> Propietarios{set;get;}

        public PropietarioServicioModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            Propietarios = repositorioPropietario.GetAllPropietarios();
        }
    }
}
