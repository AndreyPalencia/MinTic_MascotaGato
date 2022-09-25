using System;
using CuidadoEnCasa.App.Persistencia;
using CuidadoEnCasa.App.Persistencia.AppRepositorio;
using CuidadoEnCasa.App.Dominio.Entidades; 
using CuidadoEnCasa.App.Dominio;   
using System.Collections.Generic;                                                                                                                                                                

///Falta Agregar mas propietario 7 y mascotas 10
//Algunas vistas 7
//Veterinarios 10
//Realizar Filtro 
//Pagian Razor Con Base de Datos
namespace CuidadoEnCasa.App.Consola
{
    class Program
    {
      
        private static IRepositorioMascota _reposiMascota = new Repositorio(new Persistencia.AppContext());
        private static IRepositorioPropietario _reposiPropietario = new RepositorioPropietario(new Persistencia.AppContext());
        private static IRepositorioVeterinario _reposivetenitinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioVisita _reposiVista = new RepositorioVisita(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddPropietario();
            //BuscarPropietario(2);
            //BuscarPropietario(3);
            //AddMascota();
            //AddVeterinario();
            //BuscarVeterinario(1);
            //AsignarPropietario(1,2);
            //AsignarVeteniarrio(1,1);}
            //VisitaAgragda();
            //AsignarVisitaMascota(1,1);
            //AsignarVisitaVeterinarios(1,1);
            //EditarPropietario(10);
            Console.WriteLine("Andrey Palencia!");
        }

        ////////Agreagar Propietario
        private static void AddPropietario()
        {
            var propietario = new Propietario
            {
                Nombre = "Maximiliano",
                Apellido = "Simarro Toro",
                Direccion = "Avn 29 # 45 Casa 84",
                Telefono = "+01 3545-5545"
            };
            _reposiPropietario.AddPropietario(propietario);
        }
        private static void EditarPropietario(int IdPropietario)
        {
            var propietario = new Propietario
            {
                Id =  IdPropietario,
                Nombre = "Lina   ",
                Apellido = "Carmona Girasoles",
                Direccion = "Torre 31 Los Pinos Avenida 23 Casa 12 ",
                Telefono = "+55 444-64569"
            };
            _reposiPropietario.UpdatePropietario(propietario);
        }
        ////////Busca un Propietario
        private static void BuscarPropietario(int IdPropietario)
        {
            var propietario = _reposiPropietario.GetPropietario(IdPropietario);
            Console.WriteLine(propietario.Nombre + " " + propietario.Apellido +  "\n ---------\n");
        }
        ////////Agregar Una Mascota_Gato
        private static void AddMascota()
        {/*
           var mascota = new Mascota_Gato()
           {
            Nombre = "Miua",
            Codigo = "012",
            Color ="Balco y Negro",
            EstadoAnimo = "Feliz",
            Temperatura = 38,
            Raza = "Criolla",
            Peso = 45,
            SignosVitales = new List<SignosVitales>
            {//PreciónArterial Media (Pam) referencia
                new SignosVitales{FechaHora = new DateTime(2022,09,17), Valor = 125, Signo = TipoSigno.PreciónArterial},
                new SignosVitales{FechaHora = new DateTime(2022,09,17), Valor = 95, Signo = TipoSigno.SaturaciónOxigeno},
                new SignosVitales{FechaHora = new DateTime(2022,09,17), Valor = 150, Signo = TipoSigno.FrecuenciaCardica},
                new SignosVitales{FechaHora = new DateTime(2022,09,17), Valor = 35, Signo = TipoSigno.FrecuenciaRespiratoria}
            }
           };
            _reposiMascota.AddMascota(mascota);*/
        }
        ////////Agragar Un Veterinario 
        private static void AddVeterinario()
        {/*
            var Veterinario = new Veterinario
            {
                Nombre = "Cristian Franco",
                Apellido = "Flores Ramos",
                TarjeProfecional = "TV-125165",
                Telefono = "+98 1256 255"
            };

            _reposivetenitinario.AddVeterinario(Veterinario);*/
        }
        ///////Buscar Veterinario
        private static void BuscarVeterinario(int IdVeterinario)
        {
            var Veterinario = _reposivetenitinario.GetVeterinario(IdVeterinario);
            Console.Write(Veterinario.Nombre + " " + Veterinario.Apellido + "\n" +
             Veterinario.TarjeProfecional + "\n ---------\n");
        }
        ///////Asignar Propietario
        private static void AsignarPropietario(int IdMascota_Gato,int IdPropietario)
        {
            var propipretario = _reposiMascota.AsignarPropietario( IdMascota_Gato,IdPropietario);
            Console.WriteLine(propipretario.Nombre + " " + "\n Ha Adoptado Un Gato\n ---------------");
        }
        //////Asignar Veterinario
        private static void AsignarVeteniarrio(int IdMascota_Gato,int IdVeterinario)
        {
            var veterinario = _reposiMascota.AsignarVeteniarrio( IdMascota_Gato,IdVeterinario);
            Console.WriteLine(veterinario.Nombre  + " " + "\n" + veterinario.TarjeProfecional +  
             "\n Ha TratAdo Un Gato\n ---------------");
        }
        //////Agregar Visita 
        public static void VisitaAgragda()
        {
            var visitaAdicionada = new Visita
            {
                FechaVisita = new DateTime(2022,09,17,11,11,38)
            };
            _reposiVista.AddVisita(visitaAdicionada);
        }
        //////Asignar Veterinario
        private static void AsignarVisitaVeterinarios(int IdVisita,int IdVeterinario)
        {
            var Visita = _reposiVista.AsignarVeteniarrio( IdVisita,IdVeterinario);
            Console.WriteLine(Visita.FechaVisita  + " " + "\n" + "\n Ha Tratodo Un Gato\n ---------------");
        }
        private static void AsignarVisitaMascota(int IdVisita,int IdMascota_Gato)
        {
            var Visita = _reposiVista.AsignarMascota_Gato( IdVisita , IdMascota_Gato);
            Console.WriteLine(Visita.FechaVisita  + " " + "\n" + "\n Ha Tratodo Un Gato\n ---------------");
        }
    }
}
