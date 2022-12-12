using System;
using LabWareTempoEDinheroFrontEnd.Models.Authorization;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Models.ReportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Data
{
    public partial class labwareContext : DbContext
    {
        public labwareContext()
        {
        }

        public labwareContext(DbContextOptions<labwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Agentproject> Agentprojects { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
        public virtual DbSet<Timecontroltask> Timecontroltasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProjectsAgentsWorkingReportModel> ProAgentWorkModels { get; set; }
        public virtual DbSet<TasksFromProjectReportModel> TaskProjectModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=labware;uid=root;pwd=root", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.IdAgent)
                    .HasName("PRIMARY");

                entity.ToTable("agent");

                entity.Property(e => e.IdAgent).HasColumnName("idAgent");

                entity.Property(e => e.NameAgent)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nameAgent");

                entity.Property(e => e.StatusAgent)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("statusAgent");
            });

            modelBuilder.Entity<Agentproject>(entity =>
            {
                entity.HasKey(e => e.IdAgentProject)
                    .HasName("PRIMARY");

                entity.ToTable("agentproject");

                entity.HasIndex(e => e.IdAgent, "idAgent_idx");

                entity.HasIndex(e => e.IdProject, "idProjectFK_idx");

                entity.Property(e => e.IdAgentProject).HasColumnName("idAgentProject");

                entity.Property(e => e.EndAction)
                    .HasColumnType("datetime")
                    .HasColumnName("endAction");

                entity.Property(e => e.IdAgent).HasColumnName("idAgent");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.StartAction)
                    .HasColumnType("datetime")
                    .HasColumnName("startAction");

                entity.HasOne(d => d.IdAgentNavigation)
                    .WithMany(p => p.Agentprojects)
                    .HasForeignKey(d => d.IdAgent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idAgentFK");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Agentprojects)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProjectFK");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.AddressCustomer)
                    .HasMaxLength(45)
                    .HasColumnName("addressCustomer");

                entity.Property(e => e.CpfCustomer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("cpfCustomer");

                entity.Property(e => e.NameCustomer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nameCustomer");

                entity.Property(e => e.TelephoneCustomer)
                    .HasMaxLength(45)
                    .HasColumnName("telephoneCustomer");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("PRIMARY");

                entity.ToTable("project");

                entity.HasIndex(e => e.IdCustomer, "idCustomerFK_idx");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.DescriptionProject)
                    .HasMaxLength(45)
                    .HasColumnName("descriptionProject");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.LeaderProject).HasColumnName("leaderProject");

                entity.Property(e => e.NameProject)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nameProject");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.StatusProject)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("statusProject");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idCustomerFK");
            });

            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("PRIMARY");

                entity.ToTable("task");

                entity.HasIndex(e => e.IdAgentProject, "idAgentProjectFK_idx");

                entity.Property(e => e.IdTask).HasColumnName("idTask");

                entity.Property(e => e.IdAgentProject).HasColumnName("idAgentProject");

                entity.Property(e => e.Objective)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("objective");

                entity.Property(e => e.StatusTask)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("statusTask");

                entity.HasOne(d => d.IdAgentProjectNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdAgentProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idAgentProjectFK");
            });

            modelBuilder.Entity<Timecontroltask>(entity =>
            {
                entity.HasKey(e => e.IdTimeControlTask)
                    .HasName("PRIMARY");

                entity.ToTable("timecontroltask");

                entity.HasIndex(e => e.IdTask, "idTaskFK_idx");

                entity.Property(e => e.IdTimeControlTask).HasColumnName("idTimeControlTask");

                entity.Property(e => e.IdTask).HasColumnName("idTask");

                entity.Property(e => e.StartTime)
                    .HasColumnType("date")
                    .HasColumnName("startTime");

                entity.Property(e => e.StopTime)
                    .HasColumnType("date")
                    .HasColumnName("stopTime");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Timecontroltasks)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idTaskFK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.IdUsers).HasColumnName("idUsers");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ProjectsAgentsWorkingReportModel>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TasksFromProjectReportModel>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
