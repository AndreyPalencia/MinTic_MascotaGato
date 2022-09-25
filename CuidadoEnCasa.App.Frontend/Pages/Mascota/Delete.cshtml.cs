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
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
         [BindProperty]
        public  Mascota_Gato Gato { get; set; } 
       
        
        public DeleteModel()
        {
            this.repositorioMascota = new Repositorio(new CuidadoEnCasa.App.Persistencia.AppContext());
        }   
        public IActionResult  OnGet(int? Id)
        {
            if(Id.HasValue)
            {
                Gato = repositorioMascota.GetMascota(Id.Value);
            }
            if(Gato == null)
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
            if(Gato.Id  > 0)
            {
                repositorioMascota.DelecteMascota(Gato.Id);
            }
            else 
            {
                repositorioMascota.AddMascota(Gato);
            }
            return Page();
        }
    }
}
