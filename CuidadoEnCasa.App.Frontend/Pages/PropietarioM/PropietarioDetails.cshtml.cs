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
    public class PropietarioDetailsModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        public Propietario Propietarios{set;get;}
        public PropietarioDetailsModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int Id)
        {
            Propietarios = repositorioPropietario.GetPropietario(Id);
            if (Propietarios == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}
