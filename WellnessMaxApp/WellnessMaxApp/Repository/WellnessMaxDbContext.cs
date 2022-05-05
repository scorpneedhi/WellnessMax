using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WellnessMaxApp.Repository.Models;

namespace WellnessMaxApp.Repository
{
    public partial class WellnessMaxDbContext : DbContext
    {
        public WellnessMaxDbContext()
        {
        }

        public WellnessMaxDbContext(DbContextOptions<WellnessMaxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerM> CustomerMs { get; set; } = null!;
        public virtual DbSet<EnrollmentT> EnrollmentTs { get; set; } = null!;
        public virtual DbSet<OnlineCounselingM> OnlineCounselingMs { get; set; } = null!;
        public virtual DbSet<OrdersT> OrdersTs { get; set; } = null!;
        public virtual DbSet<WellnessEventM> WellnessEventMs { get; set; } = null!;
        public virtual DbSet<WellnessProductM> WellnessProductMs { get; set; } = null!;
        public virtual DbSet<WellnessProgramM> WellnessProgramMs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnrollmentT>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.EnrollmentTs)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_M_Enrollment_T");

                entity.HasOne(d => d.OnlineCounseling)
                    .WithMany(p => p.EnrollmentTs)
                    .HasForeignKey(d => d.OnlineCounselingId)
                    .HasConstraintName("FK_OnlineCounseling_M_Enrollment_T");

                entity.HasOne(d => d.WellnessEvent)
                    .WithMany(p => p.EnrollmentTs)
                    .HasForeignKey(d => d.WellnessEventId)
                    .HasConstraintName("FK_WellnessEvent_M_Enrollment_T");

                entity.HasOne(d => d.WellnessProgram)
                    .WithMany(p => p.EnrollmentTs)
                    .HasForeignKey(d => d.WellnessProgramId)
                    .HasConstraintName("FK_WellnessProgram_M_Enrollment_T");
            });

            modelBuilder.Entity<OrdersT>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrdersTs)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_M_Order_T");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersTs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WellnessProduct_M_Order_T");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
