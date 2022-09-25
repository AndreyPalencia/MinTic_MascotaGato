using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CuidadoEnCasa.App.Dominio
{
    public class Propietario
    {
        /// Se creao los atributos de la Clase Propietario Id,Nombre,Apellido,Direccion,Telefono,Mascota_Gato
        public int Id {get;set;}
        [Required, StringLength(40)]
        public String Nombre{get;set;}
        [Required, StringLength(50)]
        public String Apellido{get;set;}
        [Required, StringLength(50)]
        public String Direccion{get;set;}
        [Required, StringLength(50)]
        public String Telefono{get;set;}
    }
}