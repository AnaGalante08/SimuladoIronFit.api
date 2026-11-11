using Microsoft.EntityFrameworkCore;
using SimuladoIronFit.Api.Models;
using System.Reflection.Emit;

namespace SimuladoIronFit.Api.Data
{

    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Personal)
                .WithMany()
                .HasForeignKey(a => a.PersonalId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Aluno)
                .WithMany()
                .HasForeignKey(a => a.AlunoId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Personal)
                .WithMany()
                .HasForeignKey(a => a.PersonalId);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
