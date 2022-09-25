using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CuidadoEnCasa.App.Dominio;

namespace CuidadoEnCasa.App.Persistencia
{
    public class AppContext: DbContext
    {
        public DbSet<Mascota_Gato> Mascotas{get; set;}
        public DbSet<Propietario> Propietarios{get; set;}
        public DbSet<Veterinario> Veterinarios{get; set;}
        public DbSet<Visita> Visitas{get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =CuidadoDeMascotasEnCasa");
                
            }
        }
    
    }
}