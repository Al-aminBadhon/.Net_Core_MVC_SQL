using System;
using App.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace App.DAL.Data
{
    public partial class MHDBContext : DbContext
    {
        public MHDBContext()
        {
        }

        public MHDBContext(DbContextOptions<MHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAppliedJobs> TblAppliedJobs { get; set; }
        public virtual DbSet<TblCertificate> TblCertificate { get; set; }
        public virtual DbSet<TblCertificateType> TblCertificateType { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCrew> TblCrew { get; set; }
        public virtual DbSet<TblDesignation> TblDesignation { get; set; }
        public virtual DbSet<TblDesignationType> TblDesignationType { get; set; }
        public virtual DbSet<TblDirectors> TblDirectors { get; set; }
        public virtual DbSet<TblEducationalBackground> TblEducationalBackground { get; set; }
        public virtual DbSet<TblExecutive> TblExecutive { get; set; }
        public virtual DbSet<TblFeedBack> TblFeedBack { get; set; }
        public virtual DbSet<TblGalleryPhoto> TblGalleryPhoto { get; set; }
        public virtual DbSet<TblJobs> TblJobs { get; set; }
        public virtual DbSet<TblLoginHistory> TblLoginHistory { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-OK3LNJL\\SQLEXPRESS; database=MHDB; user id =sres_user; password=badhonrex0007; Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAppliedJobs>(entity =>
            {
                entity.HasKey(e => e.AppliedJobId);

                entity.ToTable("tblAppliedJobs");

                entity.Property(e => e.AppliedJobId)
                    .HasColumnName("AppliedJobID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CrewId).HasColumnName("CrewID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCertificate>(entity =>
            {
                entity.HasKey(e => e.CertificateId)
                    .HasName("PK_tblCertificate_1");

                entity.ToTable("tblCertificate");

                entity.Property(e => e.CertificateId)
                    .HasColumnName("CertificateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CerTypeId).HasColumnName("CerTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfIssue).HasColumnType("date");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.PlaceOfIssue).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            });

            modelBuilder.Entity<TblCertificateType>(entity =>
            {
                entity.HasKey(e => e.CerTypeId)
                    .HasName("PK_tblCertificate");

                entity.ToTable("tblCertificateType");

                entity.Property(e => e.CerTypeId)
                    .HasColumnName("CerTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CerTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("tblCompany");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            });

            modelBuilder.Entity<TblCrew>(entity =>
            {
                entity.HasKey(e => e.CrewId);

                entity.ToTable("tblCrew");

                entity.Property(e => e.CrewId).HasColumnName("CrewID");

                entity.Property(e => e.Cdcnumber)
                    .IsRequired()
                    .HasColumnName("CDCNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.CrewFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CrewLastName).HasMaxLength(50);

                entity.Property(e => e.CurrentDesgination).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmergencyContact).HasMaxLength(50);

                entity.Property(e => e.EmrgCntName).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.Height).HasMaxLength(10);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.IsOtherCdc).HasColumnName("IsOtherCDC");

                entity.Property(e => e.LinkedIn).HasMaxLength(100);

                entity.Property(e => e.MaritalStatus).HasMaxLength(10);

                entity.Property(e => e.OtherCdcnumber)
                    .HasColumnName("OtherCDCNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.PermanentAddress).HasMaxLength(200);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(50);

                entity.Property(e => e.PresentAddress).HasMaxLength(200);

                entity.Property(e => e.Relation).HasMaxLength(50);

                entity.Property(e => e.SkypeId)
                    .HasColumnName("SkypeID")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Weight).HasMaxLength(10);
            });

            modelBuilder.Entity<TblDesignation>(entity =>
            {
                entity.HasKey(e => e.DesigId)
                    .HasName("PK_Designation");

                entity.ToTable("tblDesignation");

                entity.Property(e => e.DesigId)
                    .HasColumnName("DesigID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DesigName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DesigTypeId).HasColumnName("DesigTypeID");

                entity.Property(e => e.Details).IsRequired();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DesigType)
                    .WithMany(p => p.TblDesignation)
                    .HasForeignKey(d => d.DesigTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Designation_DesignationType");
            });

            modelBuilder.Entity<TblDesignationType>(entity =>
            {
                entity.HasKey(e => e.DesigTypeId)
                    .HasName("PK_DesignationType");

                entity.ToTable("tblDesignationType");

                entity.Property(e => e.DesigTypeId).HasColumnName("DesigTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DesigName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

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

            modelBuilder.Entity<TblEducationalBackground>(entity =>
            {
                entity.HasKey(e => e.EduBackId);

                entity.ToTable("tblEducationalBackground");

                entity.Property(e => e.EduBackId).HasColumnName("EduBackID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            });

            modelBuilder.Entity<TblExecutive>(entity =>
            {
                entity.HasKey(e => e.ExecutiveId);

                entity.ToTable("tblExecutive");

                entity.Property(e => e.ExecutiveId)
                    .HasColumnName("ExecutiveID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ExFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExLastName).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            });

            modelBuilder.Entity<TblFeedBack>(entity =>
            {
                entity.HasKey(e => e.FeedBackId);

                entity.ToTable("tblFeedBack");

                entity.Property(e => e.FeedBackId).HasColumnName("FeedBackID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opinion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SenderName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblGalleryPhoto>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("tblGalleryPhoto");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Details).HasMaxLength(50);

                entity.Property(e => e.Flag).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblJobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("tblJobs");

                entity.Property(e => e.JobId)
                    .HasColumnName("JobID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeadLine).HasColumnType("datetime");

                entity.Property(e => e.Experience).HasMaxLength(50);

                entity.Property(e => e.JobDetails).IsRequired();

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Salary).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
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
