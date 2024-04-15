﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;


namespace Projeto_BackEnd.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base (options)
        { 
        }
        public DbSet<Personal> Personais { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }

    }
}
