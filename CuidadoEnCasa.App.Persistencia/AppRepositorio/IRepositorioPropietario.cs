using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio;

namespace CuidadoEnCasa.App.Persistencia.AppRepositorio
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> GetAllPropietarios();
        //Retorna todos las Propietario -> Search

        Propietario AddPropietario(Propietario propietario);
        //Agregar un Propietario que ingresa y Retorna un Propietario -> Create

        Propietario UpdatePropietario(Propietario propietario);
        //Actualizar Propietario con Propietario y retorna un Propietario ->Update

        void DelectePropietario(int IdPropietario);
        //Ingresa el IdPropietario del IdPropietario pero no retorna el IdPropietario -> Delecte 
        //Falta Discutirlo con el Grupo 
       
        Propietario GetPropietario(int IdPropietario);
        //Retorna el IdPropietario con el IdPropietario -> Search 
        //Falta Discutirlo con el Grupo 

        
       
    }
}