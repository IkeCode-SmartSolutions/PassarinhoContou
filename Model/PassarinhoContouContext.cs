using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PassarinhoContou.Model
{
    public partial class PassarinhoContouContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG 
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PassarinhoContou;User=sa;Password=iwannarock");
#endif
#if !DEBUG
            optionsBuilder.UseSqlServer(@"Server=passarinhocontou.ikecode.com.br;Database=PassarinhoContou;User=sql;Password=!@#sql)(*");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectedDevice>(entity =>
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

            modelBuilder.Entity<MessagePrefix>(entity =>
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

            modelBuilder.Entity<MessageSuffix>(entity =>
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

            modelBuilder.Entity<Message>(entity =>
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

            modelBuilder.Entity<PrefixCategory>(entity =>
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

            modelBuilder.Entity<PrefixTranslation>(entity =>
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

            modelBuilder.Entity<SuffixCategory>(entity =>
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

            modelBuilder.Entity<SuffixTranslation>(entity =>
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

            modelBuilder.Entity<User>(entity =>
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

        public virtual DbSet<ConnectedDevice> ConnectedDevices { get; set; }
        public virtual DbSet<MessagePrefix> MessagePrefixes { get; set; }
        public virtual DbSet<MessageSuffix> MessageSuffixes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PrefixCategory> PrefixCategories { get; set; }
        public virtual DbSet<PrefixCategoryTranslations> PrefixCategoryTranslations { get; set; }
        public virtual DbSet<PrefixTranslation> PrefixesTranslations { get; set; }
        public virtual DbSet<SuffixCategory> SuffixCategories { get; set; }
        public virtual DbSet<SuffixCategoryTranslations> SuffixCategoryTranslations { get; set; }
        public virtual DbSet<SuffixTranslation> SuffixesTranslations { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}