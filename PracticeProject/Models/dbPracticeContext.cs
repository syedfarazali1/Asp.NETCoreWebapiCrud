using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace PracticeProject.Models
{
    public partial class dbPracticeContext : DbContext
    {
       
        public dbPracticeContext()
        {
        }

        public dbPracticeContext(DbContextOptions<dbPracticeContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasIndex(e => e.RollNumber, "UQ__StudentD__2966FED98C943328")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.RollNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Roll_Number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
