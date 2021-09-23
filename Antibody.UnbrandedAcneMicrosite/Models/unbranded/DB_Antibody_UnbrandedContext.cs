using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Antibody.UnbrandedAcneMicrosite.Models.unbranded
{
    public partial class DB_Antibody_UnbrandedContext : DbContext
    {
        public DB_Antibody_UnbrandedContext()
        {
        }

        public DB_Antibody_UnbrandedContext(DbContextOptions<DB_Antibody_UnbrandedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserVideoProgress> UserVideoProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<UserVideoProgress>(entity =>
            {
                entity.HasKey(e => e.VideoProgressId);

                entity.ToTable("UserVideoProgress");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Misc).IsUnicode(false);

                entity.Property(e => e.ProgressSecond).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
