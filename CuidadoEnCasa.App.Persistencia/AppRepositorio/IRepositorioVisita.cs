using System;
using System.Collections.Generic;
using System.Linq;
using CuidadoEnCasa.App.Dominio;

namespace CuidadoEnCasa.App.Persistencia
{
    public interface IRepositorioVisita
    {
        // IEnumerable<Visita> GetAllVisita();
        // Retorna todos las Visita -> Search
        ////Aunque estan codificada no se implementaran en la practica
        //Falta Discutirlo con el Grupo 

        Visita AddVisita(Visita visita);
        //Agregar un Visita que ingresa y Retorna un Visita -> Create

        Visita UpdateVisita(Visita visita);
        //Actualizar Visita con visita y retorna un Visita ->Update
        ////Aunque estan codificada no se implementaran en la practica

        void DelecteVisita(int IdVisita);
        //Ingresa el IdVisita del IdVisita pero no retorna el IdVisita -> Delecte 
        ////Aunque estan codificada no se implementaran en la practica
        void DelecteVisita(DateTime FechaVisita);
        //Ingresa el FechaVisita del FechaVisita pero no retorna el FechaVisita -> Delecte 
        //Falta Discutirlo con el Grupo 
        ////Aunque estan codificada no se implementaran en la practica

        Visita GetVisita(int IdVisita);
        //Retorna el Visita con el IdVisita -> Search 
        
        Visita GetVisitaFecha(DateTime  Visita);
        //Retorna el Visita con el IdMascota_Gato pero Datos mas Filtrados Para Tratmientos o Flitrado-> Search 
        //Falta Discutirlo con el Grupo

        Visita AsignarVeteniarrio(int IdVisita , int IdVeterinario);

        Visita AsignarMascota_Gato(int IdVisita, int IdMascota_Gato);

    }
}