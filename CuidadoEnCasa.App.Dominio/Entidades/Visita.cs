using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuidadoEnCasa.App.Dominio
{
    public class Visita
    {
        /// Se creao los atributos de la Clase Visita Id,FechaVista,Veterinario,Mascota_Gato
        public int Id {get;set;}
        public DateTime FechaVisita {get;set;}
        public Veterinario Veterinario{get;set;}
        public Mascota_Gato Mascota_Gato{get;set;}

    }
}