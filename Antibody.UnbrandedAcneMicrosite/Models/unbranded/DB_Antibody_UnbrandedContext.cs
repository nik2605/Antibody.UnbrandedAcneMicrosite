using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Antibody.UnbrandedAcneMicrosite.Models.unbranded
{
    public partial class db_antibody_unbrandedContext : DbContext
    {
        public db_antibody_unbrandedContext(DbContextOptions<db_antibody_unbrandedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Uservideoprogress> Uservideoprogresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost; port=3306; database=db_antibody_unbranded; user=root; password=; Persist Security Info=False; Connect Timeout=300; SslMode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Uservideoprogress>(entity =>
            {
                entity.HasKey(e => e.VideoProgressId)
                    .HasName("PRIMARY");

                entity.ToTable("uservideoprogress");

                entity.Property(e => e.VideoProgressId).HasColumnType("int(11)");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Misc)
                    .HasColumnType("mediumtext")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProgressSecond).HasColumnType("decimal(10,2)");

                entity.Property(e => e.UserGuid)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.VideoId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
