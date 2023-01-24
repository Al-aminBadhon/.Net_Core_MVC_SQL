using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App.DAL.Models;

namespace App.DAL.Data
{
    public partial class MHDBContextOld : DbContext
    {
        public MHDBContextOld()
        {
        }

        public MHDBContextOld(DbContextOptions<MHDBContextOld> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDirectors> TblDirectors { get; set; }
        public virtual DbSet<TblLoginHistory> TblLoginHistory { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=DESKTOP-OK3LNJL\\SQLEXPRESS; database=MHDB; user id =sres_user; password=badhonrex0007; Trusted_Connection=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDirectors>(entity =>
            {
                entity.HasKey(e => e.DirectorId);

                entity.ToTable("tblDirectors");

                entity.Property(e => e.DirectorId).ValueGeneratedNever();

                entity.Property(e => e.CompanyPost).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.Details).IsRequired();

                entity.Property(e => e.DirectorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLoginHistory>(entity =>
            {
                entity.HasKey(e => e.LogHisId);

                entity.ToTable("tblLoginHistory");

                entity.Property(e => e.LogHisId)
                    .HasColumnName("LogHisID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblLoginHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLoginHistory_tblUser");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword).IsRequired();

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_tblUserRole");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("tblUserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserRoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
