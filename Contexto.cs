﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class Contexto: DbContext
    {
        public Contexto(): base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();*/
            Database.SetInitializer(new DatosdeInicio()); // Agrega datos de inicio a la base de datos despues de eliminarla
        }

        public DbSet<Cliente> Clientex { get; set; }
        public DbSet<Ciudades> Ciudadesx { get; set; }
    }
}
