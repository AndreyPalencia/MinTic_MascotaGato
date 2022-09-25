using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuidadoEnCasa.App.Dominio.Entidades;
using CuidadoEnCasa.App.Dominio;

namespace CuidadoEnCasa.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota_Gato> GetAllMascota();
        //Retorna todos las Mascota_Gato -> Search

        Mascota_Gato AddMascota(Mascota_Gato Mascota);
        //Agregar un Mascota_Gato que ingresa y Retorna un Mascota_Gato -> Create

        Mascota_Gato UpdateMascota(Mascota_Gato Mascota);
        //Actualizar Mascota_Gato con Mascota_Gato y retorna un Mascota_Gato ->Update

        void DelecteMascota(int IdMascota_Gato);
        //Ingresa el IdMascota_Gato del Mascota_Gato pero no retorna el Mascota_Gato -> Delecte 

        Mascota_Gato GetMascota(int IdMascota_Gato);
        //Retorna el Mascota_Gato con el IdMascota_Gato -> Search 
      
        //Mascota_Gato GetMascota(String CodigoMascota_Gato);
        //Retorna el Mascota_Gato con el IdMascota_Gato -> Search 
      
        
        Propietario AsignarPropietario(int IdMascota_Gato , int IdPropietario);

        Veterinario AsignarVeteniarrio(int IdMascota_Gato , int IdVeterinario);

        IEnumerable<SignosVitales> GetSignosVitales(int IdMascota_Gato);

        IEnumerable<Mascota_Gato> GetPorTemperatura(float Tempertura);

        IEnumerable<Mascota_Gato> GetPorFrecuenciaCardiaca();
        IEnumerable<Mascota_Gato> GetPorPeso(float Peso);
        

        //Metodos para Un CRUD basado En lista Mascota_Gato
        //
/*
        Mascota_Gato Uptadate(Mascota_Gato GatoActualizado);

        Mascota_Gato AddM(Mascota_Gato NuevoGato);

        Mascota_Gato GetMascotaGatoPorId(int IdGato);

        IEnumerable<Mascota_Gato> GetMascotaGatoAll();
      
       */ 
    }
}