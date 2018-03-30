using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Noted.Shared;

namespace Noted.Data
{
    public partial class NotedContext : DbContext
    {
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserNote> UserNote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Noted;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note", "ntd");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission", "ntd");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "ntd");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "ntd");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnType("binary(16)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserNote>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NoteId });

                entity.ToTable("UserNote", "ntd");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserNote");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.UserNote)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNote_Note");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserNote)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNote_Permission");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserNote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNote_User");
            });
        }
    }
}
