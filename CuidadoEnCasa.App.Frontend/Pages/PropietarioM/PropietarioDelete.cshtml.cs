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
    public class PropietarioDeleteModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        [BindProperty]
        public Propietario Propietarios{set;get;}

        public PropietarioDeleteModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        public IActionResult  OnGet(int? Id)
        {
            if(Id.HasValue)
            {
                Propietarios = repositorioPropietario.GetPropietario(Id.Value);
            }
            if(Propietarios == null)
            {
                return RedirectToPage("./NotFound");
            }
            else{
                return Page();
            }
            
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Propietarios.Id  > 0)
            {
                repositorioPropietario.DelectePropietario(Propietarios.Id);
            }
            else 
            {
                repositorioPropietario.AddPropietario(Propietarios);
            }
            return Page();
        }
    }
}
