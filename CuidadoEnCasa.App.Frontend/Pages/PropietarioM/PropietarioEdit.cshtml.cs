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
    public class PropietarioEditModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        [BindProperty]
        public Propietario Propietarios{set;get;}

        public PropietarioEditModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Propietarios = repositorioPropietario.GetPropietario(Id.Value);
                
            }else
            {
                Propietarios = new Propietario();
            }
            if (Propietarios == null)
            {
                return RedirectToPage("./NotFound"); 
            }
            else
            {
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
                Propietarios = repositorioPropietario.UpdatePropietario(Propietarios);
            }
            else 
            {
                repositorioPropietario.AddPropietario(Propietarios);
            }
            return Page();
        }
    }
}
