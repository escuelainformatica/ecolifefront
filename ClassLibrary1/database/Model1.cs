using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary1.database
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoCategoria> ProductoCategoria { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoCategoria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoCategoria>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoCategoria>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.ProductoCategoria)
                .HasForeignKey(e => e.IdCategoria);
        }
    }
}
