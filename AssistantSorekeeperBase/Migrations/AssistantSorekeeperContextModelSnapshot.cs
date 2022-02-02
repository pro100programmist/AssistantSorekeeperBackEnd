﻿// <auto-generated />
using System;
using AssistantSorekeeperBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AssistantSorekeeperBase.Migrations
{
    [DbContext(typeof(AssistantSorekeeperContext))]
    partial class AssistantSorekeeperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AssistantSorekeeperBase.Model.LinkWarehousesNomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeletedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InsertedLUPId")
                        .HasColumnType("integer");

                    b.Property<int>("NomenclatureId")
                        .HasColumnType("integer");

                    b.Property<bool>("Past")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedLUPId")
                        .HasColumnType("integer");

                    b.Property<int>("WarehousesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedLUPId");

                    b.HasIndex("InsertedLUPId");

                    b.HasIndex("NomenclatureId");

                    b.HasIndex("UpdatedLUPId");

                    b.HasIndex("WarehousesId");

                    b.ToTable("LinkWarehousesNomenclature", "Warehouses");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.LinksUserPeople", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PeoplesId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PeoplesId");

                    b.HasIndex("UserId");

                    b.ToTable("LinksUserPeople", "Users");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.MovementHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeletedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InsertedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedLUPId")
                        .HasColumnType("integer");

                    b.Property<int>("WarehousesRecipientId")
                        .HasColumnType("integer");

                    b.Property<int?>("WarehousesSenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedLUPId");

                    b.HasIndex("InsertedLUPId");

                    b.HasIndex("UpdatedLUPId");

                    b.HasIndex("WarehousesRecipientId");

                    b.HasIndex("WarehousesSenderId");

                    b.ToTable("MovementHistory", "Warehouses");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.MovementHistoryItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeletedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InsertedLUPId")
                        .HasColumnType("integer");

                    b.Property<int>("MovementHistoryId")
                        .HasColumnType("integer");

                    b.Property<int>("NomenclatureId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedLUPId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedLUPId");

                    b.HasIndex("InsertedLUPId");

                    b.HasIndex("MovementHistoryId");

                    b.HasIndex("NomenclatureId");

                    b.HasIndex("UpdatedLUPId");

                    b.ToTable("MovementHistoryItems", "Warehouses");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.Nomenclature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeletedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InsertedLUPId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedLUPId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedLUPId");

                    b.HasIndex("InsertedLUPId");

                    b.HasIndex("UpdatedLUPId");

                    b.ToTable("Nomenclature", "Warehouses");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.Peoples", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Peoples", "Users");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLoginDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("Remove")
                        .HasColumnType("boolean");

                    b.Property<int?>("RemoveLUId")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.Warehouses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeletedLUPId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InsertedLUPId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedLUPId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeletedLUPId");

                    b.HasIndex("InsertedLUPId");

                    b.HasIndex("UpdatedLUPId");

                    b.ToTable("Warehouses", "Warehouses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.LinkWarehousesNomenclature", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "DeletedLUP")
                        .WithMany()
                        .HasForeignKey("DeletedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "InsertedLUP")
                        .WithMany()
                        .HasForeignKey("InsertedLUPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.Nomenclature", "Nomenclature")
                        .WithMany()
                        .HasForeignKey("NomenclatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "UpdatedLUP")
                        .WithMany()
                        .HasForeignKey("UpdatedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.Warehouses", "Warehouses")
                        .WithMany()
                        .HasForeignKey("WarehousesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeletedLUP");

                    b.Navigation("InsertedLUP");

                    b.Navigation("Nomenclature");

                    b.Navigation("UpdatedLUP");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.LinksUserPeople", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.Peoples", "Peoples")
                        .WithMany()
                        .HasForeignKey("PeoplesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Peoples");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.MovementHistory", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "DeletedLUP")
                        .WithMany()
                        .HasForeignKey("DeletedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "InsertedLUP")
                        .WithMany()
                        .HasForeignKey("InsertedLUPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "UpdatedLUP")
                        .WithMany()
                        .HasForeignKey("UpdatedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.Warehouses", "WarehousesRecipient")
                        .WithMany()
                        .HasForeignKey("WarehousesRecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.Warehouses", "WarehousesSender")
                        .WithMany()
                        .HasForeignKey("WarehousesSenderId");

                    b.Navigation("DeletedLUP");

                    b.Navigation("InsertedLUP");

                    b.Navigation("UpdatedLUP");

                    b.Navigation("WarehousesRecipient");

                    b.Navigation("WarehousesSender");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.MovementHistoryItems", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "DeletedLUP")
                        .WithMany()
                        .HasForeignKey("DeletedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "InsertedLUP")
                        .WithMany()
                        .HasForeignKey("InsertedLUPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.MovementHistory", "MovementHistory")
                        .WithMany()
                        .HasForeignKey("MovementHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.Nomenclature", "Nomenclature")
                        .WithMany()
                        .HasForeignKey("NomenclatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "UpdatedLUP")
                        .WithMany()
                        .HasForeignKey("UpdatedLUPId");

                    b.Navigation("DeletedLUP");

                    b.Navigation("InsertedLUP");

                    b.Navigation("MovementHistory");

                    b.Navigation("Nomenclature");

                    b.Navigation("UpdatedLUP");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.Nomenclature", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "DeletedLUP")
                        .WithMany()
                        .HasForeignKey("DeletedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "InsertedLUP")
                        .WithMany()
                        .HasForeignKey("InsertedLUPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "UpdatedLUP")
                        .WithMany()
                        .HasForeignKey("UpdatedLUPId");

                    b.Navigation("DeletedLUP");

                    b.Navigation("InsertedLUP");

                    b.Navigation("UpdatedLUP");
                });

            modelBuilder.Entity("AssistantSorekeeperBase.Model.Warehouses", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "DeletedLUP")
                        .WithMany()
                        .HasForeignKey("DeletedLUPId");

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "InsertedLUP")
                        .WithMany()
                        .HasForeignKey("InsertedLUPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.LinksUserPeople", "UpdatedLUP")
                        .WithMany()
                        .HasForeignKey("UpdatedLUPId");

                    b.Navigation("DeletedLUP");

                    b.Navigation("InsertedLUP");

                    b.Navigation("UpdatedLUP");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantSorekeeperBase.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AssistantSorekeeperBase.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
