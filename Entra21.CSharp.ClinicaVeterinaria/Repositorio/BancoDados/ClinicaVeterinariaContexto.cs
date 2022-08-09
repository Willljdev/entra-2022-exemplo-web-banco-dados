﻿using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados
{
    public class ClinicaVeterinariaContexto : DbContext
    {
        public DbSet<Raca> Racas { get; set; }
        public ClinicaVeterinariaContexto(
            DbContextOptions<ClinicaVeterinariaContexto> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Raca>().ToTable("racas");
        }
    }
}