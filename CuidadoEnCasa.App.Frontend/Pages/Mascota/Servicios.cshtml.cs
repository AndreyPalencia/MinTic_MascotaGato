using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace CuidadoEnCasa.App.Frontend.Pages
{
     //[Authorize]
    public class ServiciosModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;

        public IEnumerable<Mascota_Gato> Gatos {get;set;}
        /*IRepositorioMascota repositorioMascota*/
        public ServiciosModel()
        {
            //this.irepositorioMascota = repositorioMascota;
            this.repositorioMascota = new Repositorio(new CuidadoEnCasa.App.Persistencia.AppContext());
        }
        
        public void OnGet()
        {
            Gatos = repositorioMascota.GetAllMascota();
        }
        
    }
}
