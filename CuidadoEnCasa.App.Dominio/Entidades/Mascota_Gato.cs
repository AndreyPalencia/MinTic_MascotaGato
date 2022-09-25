using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CuidadoEnCasa.App.Dominio.Entidades;

namespace CuidadoEnCasa.App.Dominio
{
    public class Mascota_Gato
    {
        /// Se creao los atributos de la Clase Mascota_Gato Id,Nombre,Color,EstadoAnimo,Temperatura,Peso,
        /// FrecuenciaCardiaca,FrecuenciaRespiratoria,Raza
       
        public int  Id {get;set;}
        

        public String Nombre{get;set;}
        

        public String Codigo {get;set;}
        
        public String Color {get;set;}
        

        public String EstadoAnimo{get;set;}

        public float Temperatura{get;set;}
        

        public float Peso{get;set;}

        public String Raza{get;set;}

        public Propietario Propietario{get;set;}

        public Veterinario  Veterinario {get;set;}

        public System.Collections.Generic.List<SignosVitales> SignosVitales { get; set; }
        
    }
}