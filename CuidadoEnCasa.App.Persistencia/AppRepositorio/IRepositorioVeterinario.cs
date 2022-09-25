using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio;

namespace CuidadoEnCasa.App.Persistencia.AppRepositorio
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinario();
        //Retorna todos las Veterinario -> Search

        Veterinario AddVeterinario(Veterinario veterinario);
        //Agregar un Veterinario que ingresa y Retorna un Veterinario -> Create

        Veterinario UpdateVeterinario(Veterinario veterinario);
        //Actualizar Veterinario con Veterinario y retorna un Veterinario ->Update

        void DelecteVeterinario(int IdVeterinario);
        //Ingresa el IdVeterinario del IdVeterinario pero no retorna el IdVeterinario -> Delecte 
        //Falta Discutirlo con el Grupo 

        Veterinario GetVeterinario(int IdVeterinario);
        //Retorna el IdVeterinario con el IdVeterinario -> Search 
        //Falta Discutirlo con el Grupo 
        
        
    }
}