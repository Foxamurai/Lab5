using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Db
{
    class AppDbContext : DbContext
    {       

        public virtual DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public virtual DbSet<RealEstateObject> RealEstateObjects { get; set; }
        public virtual DbSet<Realtor> Realtors { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<RealEstateType> RealEstateTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildingMaterial>();

            modelBuilder.Entity<District>();

            // Оценка => Объект недвижимости
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.RealEstateObject)
                .WithMany(reo => reo.Evaluations)
                .HasForeignKey(e => e.RealEstateObjectId);

            // Оценка => Критерий оценки
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.EvaluationCriteria)
                .WithMany(reo => reo.Evaluations)
                .HasForeignKey(e => e.EvaluationCriteriaId);

            modelBuilder.Entity<EvaluationCriteria>();               

            // Объект недвижимости => Район
            modelBuilder.Entity<RealEstateObject>()
                .HasOne(reo => reo.District)
                .WithMany(d => d.RealEstateObjects)
                .HasForeignKey(reo => reo.DistrictId);

            // Объект недвижимости => Тип недвижимости
            modelBuilder.Entity<RealEstateObject>()
                .HasOne(reo => reo.RealEstateType)
                .WithMany(d => d.RealEstateObjects)
                .HasForeignKey(reo => reo.RealEstateTypeId);

            // Объект недвижимости => Материал здания
            modelBuilder.Entity<RealEstateObject>()
                .HasOne(reo => reo.BuildingMaterial)
                .WithMany(d => d.RealEstateObjects)
                .HasForeignKey(reo => reo.BuldingMaterialId);


            modelBuilder.Entity<Realtor>();

            // Продажа => Объект недвижимости
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.RealEstateObject)
                .WithMany(reo => reo.Sales)
                .HasForeignKey(s => s.RealEstateObjectId);

            // Продажа => Риелтор
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Realtor)
                .WithMany(reo => reo.Sales)
                .HasForeignKey(s => s.RealtorId);

            modelBuilder.Entity<RealEstateType>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Lab5DB; Trusted_Connection=True;");
        }
    }
}

