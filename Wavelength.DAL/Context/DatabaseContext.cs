using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wavelength.DAL.DomainModels;

namespace Wavelength.DAL.Context {
    public class DatabaseContext : DbContext, IDBContext {
        public DatabaseContext() : base("Wavelength") { }
        public DbSet<CardData> Cards { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class {
            return base.Set<TEntity>();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<DbContext>(null);
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<CardData>().Map(m => {
                m.MapInheritedProperties();
                m.ToTable("Cards");
            });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}