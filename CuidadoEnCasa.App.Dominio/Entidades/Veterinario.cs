using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CuidadoEnCasa.App.Dominio
{
    public class Veterinario
    {
        /// Se creao los atributos de la Clase Veterinario Id,Nombres,Telefono,TarjeProfecional,Apellidos
        public int  Id {get;set;}

        [Required, StringLength(50)]
        public String Nombre{get;set;}
        [Required, StringLength(50)]
        public String Apellido{get;set;}
        [Required, StringLength(50)]
        public String Telefono  {get;set;}
        [Required, StringLength(50)]
        public String TarjeProfecional {get;set;}
        
    }
}