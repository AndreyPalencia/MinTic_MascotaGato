using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuidadoEnCasa.App.Dominio.Entidades
{
    public class SignosVitales
    {
        public int Id { get; set; }
        /// Fecha y hora en que se realizó la toma del signo vital 
        public DateTime FechaHora  { get; set; }
         /// Valor numérico del sifno vital  
        public float Valor {get;set;}
        /// Tipo de Signo vital medido
        public TipoSigno Signo { get; set; }

        
    }
}