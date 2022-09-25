using System;
using System.Collections.Generic;
using System.Linq;
using CuidadoEnCasa.App.Dominio;
using CuidadoEnCasa.App.Dominio.Entidades;

using CuidadoEnCasa.App.Persistencia.AppRepositorio;
using Microsoft.EntityFrameworkCore;

namespace CuidadoEnCasa.App.Persistencia
{
    public class Repositorio :  IRepositorioMascota
    {
        
        private readonly AppContext _appContext;
         
        /// <summary>
        /// 
        //<param name="appContext"> </param>
        public Repositorio(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        /////CRUD Mascota_Gato
        IEnumerable<Mascota_Gato> IRepositorioMascota.GetAllMascota()
        {
            return _appContext.Mascotas;
        }

        Mascota_Gato IRepositorioMascota.AddMascota(Mascota_Gato Mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(Mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        Mascota_Gato IRepositorioMascota.UpdateMascota(Mascota_Gato Mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == Mascota.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = Mascota.Nombre;
                mascotaEncontrada.Color = Mascota.Color;
                mascotaEncontrada.EstadoAnimo = Mascota.EstadoAnimo;
                mascotaEncontrada.Temperatura = Mascota.Temperatura;
                mascotaEncontrada.Veterinario = Mascota.Veterinario;
                mascotaEncontrada.Peso = Mascota.Peso;
                mascotaEncontrada.SignosVitales = Mascota.SignosVitales;
                mascotaEncontrada.Raza = Mascota.Raza;

                _appContext.SaveChanges();

            }
            return mascotaEncontrada;
        }

        void IRepositorioMascota.DelecteMascota(int IdMascota_Gato)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota_Gato);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }


        Mascota_Gato IRepositorioMascota.GetMascota(int IdMascota_Gato)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == IdMascota_Gato);
        }

        /*Mascota_Gato IRepositorioMascota.GetMascota(string CodigoMascota_Gato)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Codigo == CodigoMascota_Gato);
        }*/


        Propietario IRepositorioMascota.AsignarPropietario(int IdMascota_Gato, int IdPropietario)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(p => p.Id == IdMascota_Gato);
            if (mascotaEncontrada != null)
            {
                var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(m => m.Id == IdPropietario);
                if (propietarioEncontrado != null)
                {
                    mascotaEncontrada.Propietario = propietarioEncontrado;
                    _appContext.SaveChanges();
                }
                return propietarioEncontrado;
            }
            return null;
        }

        Veterinario IRepositorioMascota.AsignarVeteniarrio(int IdMascota_Gato, int IdVeterinario)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(p => p.Id == IdMascota_Gato);
            if (mascotaEncontrada != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(m => m.Id == IdVeterinario);
                if (veterinarioEncontrado != null)
                {
                    mascotaEncontrada.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

        //////////////Filtros
        IEnumerable<Mascota_Gato> IRepositorioMascota.GetPorTemperatura(float Tempertura)
        {
            return _appContext.Mascotas.
            Where(m => m.Temperatura == Tempertura);
        }

        IEnumerable<Mascota_Gato> IRepositorioMascota.GetPorFrecuenciaCardiaca()
        {
            return _appContext.Mascotas.
            Where(m => m.SignosVitales.Any(s => TipoSigno.FrecuenciaCardica == s.Signo && s.Valor >= 142)).ToList();
        }

        IEnumerable<SignosVitales> IRepositorioMascota.GetSignosVitales(int IdMascota_Gato)
        {
            var mascota = _appContext.Mascotas.Where(m => m.Id==IdMascota_Gato)
            .Include(m=>m.SignosVitales).FirstOrDefault();

            return mascota.SignosVitales;
        }

        IEnumerable<Mascota_Gato> IRepositorioMascota.GetPorPeso(float Peso)
        {
            return _appContext.Mascotas.
            Where(m => m.Peso == Peso);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        //////////////////////////////////CRUD Mascota_Gato////////////////////////////////
        /*
               //Se Crea un List de Mascota_Gato llamada Gato para imitar una base de datos 
               List<Mascota_Gato> Gato;

               //Se inicializa el contructor con objeto de Mascota_Gata agregandolo a la lista ya creada en Gato
                public Repositorio()
                {//Falta craar un prpietario
                    Gato = new List<Mascota_Gato>()
                    {
                        new Mascota_Gato{Id = 1, Nombre = "Perla", Codigo = "001",Color = "Blanca Y Negra", Temperatura = 32,
                        Peso = "50", *FrecuenciaCardiaca = "125", FrecuenciaRespiratoria = "156",*Raza = "Criolla" ,propietario = {Id = 023 ,
                         Nombres = "Juan Pedro ", Apellidos = "Pedrosa" , Direccion = "Calle 45 Av 065", Telefono = "35645 454"} },

                        new Mascota_Gato{Id = 2, Nombre = "Miau", Codigo = "002",Color = "Dorada", Temperatura = 42,
                        Peso = "56", *FrecuenciaCardiaca = "123", FrecuenciaRespiratoria = "155",*Raza = "Criolla" ,propietario = {} },
                        new Mascota_Gato{Id = 3, Nombre = "Federico", Codigo = "003",Color = "Blanca ", Temperatura = 92,
                        Peso = "35",* FrecuenciaCardiaca = "110", FrecuenciaRespiratoria= "158",*Raza = "Criolla" ,propietario = {} }

                    };
                }


                // Se codifica los  metodos Add y Uptadate ya creado en interfaz IRepositorioMascota para trabajar con la lista 
                //Y poder realizar codigo
                public Mascota_Gato Uptadate(Mascota_Gato GatoActualizado)
                {
                    var Mascota_Gatos = Gato.FirstOrDefault(r => r.Id == GatoActualizado.Id);
                    if (Mascota_Gatos != null)
                    {
                        Mascota_Gatos.Nombre = GatoActualizado.Nombre;
                        Mascota_Gatos.Codigo = GatoActualizado.Codigo;
                        Mascota_Gatos.Color = GatoActualizado.Color;
                        Mascota_Gatos.EstadoAnimo = GatoActualizado.EstadoAnimo;
                        Mascota_Gatos.Temperatura = GatoActualizado.Temperatura;
                        Mascota_Gatos.Peso = GatoActualizado.Peso;
                        Mascota_Gatos.Raza = GatoActualizado.Raza;

                    }
                    return Mascota_Gatos;
                }

                public Mascota_Gato AddM(Mascota_Gato NuevoGato)
                {
                    NuevoGato.Id = Gato.Max(r => r.Id) + 1;
                    Gato.Add(NuevoGato);
                    return NuevoGato;
                }

                public Mascota_Gato GetMascotaGatoPorId(int IdGato)
                {
                    return Gato.SingleOrDefault(G => G.Id == IdGato);
                }

                public IEnumerable<Mascota_Gato> GetMascotaGatoAll()
                {
                    return Gato;
                }
                        Mascota_Gato IRepositorioMascota.Uptadate(Mascota_Gato GatoActualizado)
                {
                    throw new NotImplementedException();
                }

                Mascota_Gato IRepositorioMascota.AddM(Mascota_Gato NuevoGato)
                {
                    throw new NotImplementedException();
                }

                Mascota_Gato IRepositorioMascota.GetMascotaGatoPorId(int IdGato)
                {
                    throw new NotImplementedException();
                }

                IEnumerable<Mascota_Gato> IRepositorioMascota.GetMascotaGatoAll()
                {
                    throw new NotImplementedException();
                }
                */



    }
}