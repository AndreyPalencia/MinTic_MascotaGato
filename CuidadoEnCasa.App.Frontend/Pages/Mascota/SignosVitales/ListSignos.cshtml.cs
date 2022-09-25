using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CuidadoEnCasa.App.Dominio.Entidades;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia;

namespace CuidadoEnCasa.App.Frontend.Pages
{
    public class ListSignosModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public  Mascota_Gato Gato { get; set; } 
       
        public IEnumerable<SignosVitales> Signos {get; set;} 

        public ListSignosModel()
        {
            this.repositorioMascota = new Repositorio(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        public void OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Gato = repositorioMascota.GetMascota(Id.Value);
            }

            if (Gato == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                Signos = repositorioMascota.GetSignosVitales(Id.Value);
            }
   
        }
    }
}
