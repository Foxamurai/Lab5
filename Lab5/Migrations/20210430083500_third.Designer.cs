// <auto-generated />
using System;
using Lab5.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210430083500_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab5.Models.BuildingMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuildingMaterials");
                });

            modelBuilder.Entity("Lab5.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Lab5.Models.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EvaluationCriteriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EvaluationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EvaluationResult")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateObjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationCriteriaId");

                    b.HasIndex("RealEstateObjectId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Lab5.Models.EvaluationCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EvaluationCriterias");
                });

            modelBuilder.Entity("Lab5.Models.RealEstateObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("BuldingMaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RealEstateTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BuldingMaterialId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("RealEstateTypeId");

                    b.ToTable("RealEstateObjects");
                });

            modelBuilder.Entity("Lab5.Models.RealEstateType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RealEstateTypes");
                });

            modelBuilder.Entity("Lab5.Models.Realtor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Realtors");
                });

            modelBuilder.Entity("Lab5.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RealEstateObjectId")
                        .HasColumnType("int");

                    b.Property<int>("RealtorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateObjectId");

                    b.HasIndex("RealtorId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Lab5.Models.Evaluation", b =>
                {
                    b.HasOne("Lab5.Models.EvaluationCriteria", "EvaluationCriteria")
                        .WithMany("Evaluations")
                        .HasForeignKey("EvaluationCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.RealEstateObject", "RealEstateObject")
                        .WithMany("Evaluations")
                        .HasForeignKey("RealEstateObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvaluationCriteria");

                    b.Navigation("RealEstateObject");
                });

            modelBuilder.Entity("Lab5.Models.RealEstateObject", b =>
                {
                    b.HasOne("Lab5.Models.BuildingMaterial", "BuildingMaterial")
                        .WithMany("RealEstateObjects")
                        .HasForeignKey("BuldingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.District", "District")
                        .WithMany("RealEstateObjects")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.RealEstateType", "RealEstateType")
                        .WithMany("RealEstateObjects")
                        .HasForeignKey("RealEstateTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingMaterial");

                    b.Navigation("District");

                    b.Navigation("RealEstateType");
                });

            modelBuilder.Entity("Lab5.Models.Sale", b =>
                {
                    b.HasOne("Lab5.Models.RealEstateObject", "RealEstateObject")
                        .WithMany("Sales")
                        .HasForeignKey("RealEstateObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab5.Models.Realtor", "Realtor")
                        .WithMany("Sales")
                        .HasForeignKey("RealtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstateObject");

                    b.Navigation("Realtor");
                });

            modelBuilder.Entity("Lab5.Models.BuildingMaterial", b =>
                {
                    b.Navigation("RealEstateObjects");
                });

            modelBuilder.Entity("Lab5.Models.District", b =>
                {
                    b.Navigation("RealEstateObjects");
                });

            modelBuilder.Entity("Lab5.Models.EvaluationCriteria", b =>
                {
                    b.Navigation("Evaluations");
                });

            modelBuilder.Entity("Lab5.Models.RealEstateObject", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Lab5.Models.RealEstateType", b =>
                {
                    b.Navigation("RealEstateObjects");
                });

            modelBuilder.Entity("Lab5.Models.Realtor", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
