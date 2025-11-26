using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_VNR.Controllers;
using PF_VNR.Data;
using PF_VNR.Models;

namespace PF_VNR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<MedicionRuido> MedicionesRuido { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lugar>().ToTable("Lugar");
            modelBuilder.Entity<MedicionRuido>().ToTable("MedicionRuido");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Rol>().ToTable("Rol");

            modelBuilder.Entity<MedicionRuido>()
                .HasOne(m => m.Lugar)
                .WithMany(l => l.Mediciones)
                .HasForeignKey(m => m.LugarId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);
        }
    }
}
