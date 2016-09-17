using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PassarinhoContou.Model
{
    public partial class PassarinhoContouContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PassarinhoContouNew;User=sa;Password=iwannarock");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectedDevices>(entity =>
            {
                entity.Property(e => e.ConfirmationCode).HasColumnType("varchar(500)");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectedDevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ConnectedDevices_Users");
            });

            modelBuilder.Entity<MessagePrefixes>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.PrefixCategory)
                    .WithMany(p => p.MessagePrefixes)
                    .HasForeignKey(d => d.PrefixCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MessagePrefixes_PrefixCategories");
            });

            modelBuilder.Entity<MessageSuffixes>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.SuffixCategory)
                    .WithMany(p => p.MessageSuffixes)
                    .HasForeignKey(d => d.SuffixCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MessageSuffixes_SuffixCategories");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MessagesFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Messages_FromUser");

                entity.HasOne(d => d.SelectedPrefix)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SelectedPrefixId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Messages_MessagePrefixes");

                entity.HasOne(d => d.SelectedSuffix)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SelectedSuffixId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Messages_MessageSuffixes");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MessagesToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Messages_ToUser");
            });

            modelBuilder.Entity<PrefixCategories>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<PrefixCategoryTranslations>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryText)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.PrefixCategory)
                    .WithMany(p => p.PrefixCategoryTranslations)
                    .HasForeignKey(d => d.PrefixCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PrefixCategoryTranslations_PrefixCategories");
            });

            modelBuilder.Entity<PrefixesTranslations>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Prefix)
                    .WithMany(p => p.PrefixesTranslations)
                    .HasForeignKey(d => d.PrefixId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PrefixesTranslations_MessagePrefixes");
            });

            modelBuilder.Entity<SuffixCategories>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<SuffixCategoryTranslations>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CategoryText)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.PrefixCategory)
                    .WithMany(p => p.SuffixCategoryTranslations)
                    .HasForeignKey(d => d.PrefixCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SuffixCategoryTranslations_SuffixCategories");
            });

            modelBuilder.Entity<SuffixesTranslations>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Suffix)
                    .WithMany(p => p.SuffixesTranslations)
                    .HasForeignKey(d => d.SuffixId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SuffixesTranslations_MessageSuffixes");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(20)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });
        }

        public virtual DbSet<ConnectedDevices> ConnectedDevices { get; set; }
        public virtual DbSet<MessagePrefixes> MessagePrefixes { get; set; }
        public virtual DbSet<MessageSuffixes> MessageSuffixes { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<PrefixCategories> PrefixCategories { get; set; }
        public virtual DbSet<PrefixCategoryTranslations> PrefixCategoryTranslations { get; set; }
        public virtual DbSet<PrefixesTranslations> PrefixesTranslations { get; set; }
        public virtual DbSet<SuffixCategories> SuffixCategories { get; set; }
        public virtual DbSet<SuffixCategoryTranslations> SuffixCategoryTranslations { get; set; }
        public virtual DbSet<SuffixesTranslations> SuffixesTranslations { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}