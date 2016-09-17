using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PassarinhoContou.Model;

namespace PassarinhoContou.Model.Migrations
{
    [DbContext(typeof(PassarinhoContouContext))]
    partial class PassarinhoContouContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PassarinhoContou.Model.ConnectedDevices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmationCode")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Owner");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ConnectedDevices");
                });

            modelBuilder.Entity("PassarinhoContou.Model.MessagePrefixes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Owner");

                    b.Property<int>("PrefixCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("PrefixCategoryId");

                    b.ToTable("MessagePrefixes");
                });

            modelBuilder.Entity("PassarinhoContou.Model.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FromUserId");

                    b.Property<int>("LanguageId");

                    b.Property<int>("MessageType");

                    b.Property<int>("Owner");

                    b.Property<int>("SelectedPrefixId");

                    b.Property<int>("SelectedSuffixId");

                    b.Property<int>("Status");

                    b.Property<int>("ToUserId");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("SelectedPrefixId");

                    b.HasIndex("SelectedSuffixId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PassarinhoContou.Model.MessageSuffixes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Owner");

                    b.Property<int>("SuffixCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("SuffixCategoryId");

                    b.ToTable("MessageSuffixes");
                });

            modelBuilder.Entity("PassarinhoContou.Model.PrefixCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Owner");

                    b.HasKey("Id");

                    b.ToTable("PrefixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.PrefixCategoryTranslations", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CategoryText")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LanguageId");

                    b.Property<int>("Owner");

                    b.Property<int>("PrefixCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("PrefixCategoryId");

                    b.ToTable("PrefixCategoryTranslations");
                });

            modelBuilder.Entity("PassarinhoContou.Model.PrefixesTranslations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LanguageId");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Owner");

                    b.Property<int>("PrefixId");

                    b.HasKey("Id");

                    b.HasIndex("PrefixId");

                    b.ToTable("PrefixesTranslations");
                });

            modelBuilder.Entity("PassarinhoContou.Model.SuffixCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Owner");

                    b.HasKey("Id");

                    b.ToTable("SuffixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.SuffixCategoryTranslations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryText")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LanguageId");

                    b.Property<int>("Owner");

                    b.Property<int>("PrefixCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("PrefixCategoryId");

                    b.ToTable("SuffixCategoryTranslations");
                });

            modelBuilder.Entity("PassarinhoContou.Model.SuffixesTranslations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LanguageId");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Owner");

                    b.Property<int>("SuffixId");

                    b.HasKey("Id");

                    b.HasIndex("SuffixId");

                    b.ToTable("SuffixesTranslations");
                });

            modelBuilder.Entity("PassarinhoContou.Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Owner");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PassarinhoContou.Model.ConnectedDevices", b =>
                {
                    b.HasOne("PassarinhoContou.Model.Users", "User")
                        .WithMany("ConnectedDevices")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ConnectedDevices_Users");
                });

            modelBuilder.Entity("PassarinhoContou.Model.MessagePrefixes", b =>
                {
                    b.HasOne("PassarinhoContou.Model.PrefixCategories", "PrefixCategory")
                        .WithMany("MessagePrefixes")
                        .HasForeignKey("PrefixCategoryId")
                        .HasConstraintName("FK_MessagePrefixes_PrefixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.Messages", b =>
                {
                    b.HasOne("PassarinhoContou.Model.Users", "FromUser")
                        .WithMany("MessagesFromUser")
                        .HasForeignKey("FromUserId")
                        .HasConstraintName("FK_Messages_FromUser");

                    b.HasOne("PassarinhoContou.Model.MessagePrefixes", "SelectedPrefix")
                        .WithMany("Messages")
                        .HasForeignKey("SelectedPrefixId")
                        .HasConstraintName("FK_Messages_MessagePrefixes");

                    b.HasOne("PassarinhoContou.Model.MessageSuffixes", "SelectedSuffix")
                        .WithMany("Messages")
                        .HasForeignKey("SelectedSuffixId")
                        .HasConstraintName("FK_Messages_MessageSuffixes");

                    b.HasOne("PassarinhoContou.Model.Users", "ToUser")
                        .WithMany("MessagesToUser")
                        .HasForeignKey("ToUserId")
                        .HasConstraintName("FK_Messages_ToUser");
                });

            modelBuilder.Entity("PassarinhoContou.Model.MessageSuffixes", b =>
                {
                    b.HasOne("PassarinhoContou.Model.SuffixCategories", "SuffixCategory")
                        .WithMany("MessageSuffixes")
                        .HasForeignKey("SuffixCategoryId")
                        .HasConstraintName("FK_MessageSuffixes_SuffixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.PrefixCategoryTranslations", b =>
                {
                    b.HasOne("PassarinhoContou.Model.PrefixCategories", "PrefixCategory")
                        .WithMany("PrefixCategoryTranslations")
                        .HasForeignKey("PrefixCategoryId")
                        .HasConstraintName("FK_PrefixCategoryTranslations_PrefixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.PrefixesTranslations", b =>
                {
                    b.HasOne("PassarinhoContou.Model.MessagePrefixes", "Prefix")
                        .WithMany("PrefixesTranslations")
                        .HasForeignKey("PrefixId")
                        .HasConstraintName("FK_PrefixesTranslations_MessagePrefixes");
                });

            modelBuilder.Entity("PassarinhoContou.Model.SuffixCategoryTranslations", b =>
                {
                    b.HasOne("PassarinhoContou.Model.SuffixCategories", "PrefixCategory")
                        .WithMany("SuffixCategoryTranslations")
                        .HasForeignKey("PrefixCategoryId")
                        .HasConstraintName("FK_SuffixCategoryTranslations_SuffixCategories");
                });

            modelBuilder.Entity("PassarinhoContou.Model.SuffixesTranslations", b =>
                {
                    b.HasOne("PassarinhoContou.Model.MessageSuffixes", "Suffix")
                        .WithMany("SuffixesTranslations")
                        .HasForeignKey("SuffixId")
                        .HasConstraintName("FK_SuffixesTranslations_MessageSuffixes");
                });
        }
    }
}
