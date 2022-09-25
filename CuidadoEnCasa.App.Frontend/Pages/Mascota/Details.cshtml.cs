using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia;

namespace CuidadoEnCasa.App.Frontend.Pages
{
    
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        
        public Mascota_Gato Gato { get; set; }
        /*IRepositorioMascota irepositorioMascota*/
        public DetailsModel()
        {
            this.repositorioMascota = new Repositorio(new CuidadoEnCasa.App.Persistencia.AppContext());;
        }
    
        public IActionResult OnGet(int Id)
        {
            Gato = repositorioMascota.GetMascota(Id);
            if (Gato == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}
