using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PRN221.Team5.Domain.Entity;

namespace Team5.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }

        #region DbSet
        private DbSet<Account> Accounts { get; set; }
        private DbSet<ZooNews> ZooNews { get; set; }
        private DbSet<TraineerProfile> TraineerProfiles { get; set; }
        private DbSet<AnimalTraining> AnimalTrainings { get; set; }
        private DbSet<Animal> Animals { get; set; }
        private DbSet<AnimalSpecie> AnimalSpecies { get; set; }
        private DbSet<ZooSection> ZooSections { get; set; }
        private DbSet<Cage> Cages { get; set; }
        private DbSet<Cage_Animal> Cage_Animals { get; set; }
        private DbSet<Food> Foods { get; set; }
        private DbSet<Meal> Meals { get; set; }
        private DbSet<Meal_Animal> Meal_Animals { get; set; }
        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //config for Account - ZooNews one-to-many relationship
            modelBuilder.Entity<Account>()
               .HasMany(a => a.ZooNews)
               .WithOne(z => z.Owner)
               .HasForeignKey(z => z.OwnerId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for Account - TraineerProfile one-to-one relationship
            modelBuilder.Entity<TraineerProfile>()
              .HasOne(a => a.Account)
              .WithOne(a => a.TraineerProfile)
              .HasForeignKey<TraineerProfile>(z => z.AccountId)
              .OnDelete(DeleteBehavior.Cascade);

            //config for Animal - AnimalTraining one-to-many relationship
            modelBuilder.Entity<Animal>()
               .HasMany(a => a.AnimalTrainings)
               .WithOne(z => z.Animal)
               .HasForeignKey(z => z.AnimalId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for TraineerProfile - AnimalTraining one-to-many relationship
            modelBuilder.Entity<TraineerProfile>()
               .HasMany(a => a.AnimalTrainings)
               .WithOne(z => z.Trainer)
               .HasForeignKey(z => z.TrainerId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for AnimalSpecie - Animal one-to-many relationship
            modelBuilder.Entity<AnimalSpecie>()
               .HasMany(a => a.Animals)
               .WithOne(z => z.Specie)
               .HasForeignKey(z => z.SpecieId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for ZooSection - Cage one-to-many relationship
            modelBuilder.Entity<ZooSection>()
               .HasMany(a => a.Cages)
               .WithOne(z => z.ZooSection)
               .HasForeignKey(z => z.ZooSectionId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for AnimalSpecie - Cage one-to-many relationship
            modelBuilder.Entity<AnimalSpecie>()
               .HasMany(a => a.Cages)
               .WithOne(z => z.AnimalSpecie)
               .HasForeignKey(z => z.AnimalSpecieId)
               .OnDelete(DeleteBehavior.NoAction);

            //config for Cage - Cage_Animal one-to-many relationship
            modelBuilder.Entity<Cage>()
               .HasMany(a => a.Cage_Animals)
               .WithOne(z => z.Cage)
               .HasForeignKey(z => z.CageId)
               .OnDelete(DeleteBehavior.NoAction);

            //config for Animal - Cage_Animal one-to-many relationship
            modelBuilder.Entity<Animal>()
               .HasMany(a => a.Cage_Animals)
               .WithOne(z => z.Animal)
               .HasForeignKey(z => z.AnimalId)
               .OnDelete(DeleteBehavior.NoAction);

            //config for Mea - Food many-to-many relationship
            modelBuilder.Entity<Food>()
               .HasMany(a => a.Meal_Foods)
               .WithOne(z => z.Food)
               .HasForeignKey(z => z.FoodId)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Meal>()
              .HasMany(a => a.Meal_Foods)
              .WithOne(z => z.Meal)
              .HasForeignKey(z => z.MealId)
              .OnDelete(DeleteBehavior.NoAction);

            //config for Meal - Animal one-to-many relationship
            modelBuilder.Entity<Meal>()
               .HasMany(a => a.Meal_Animals)
               .WithOne(z => z.Meal)
               .HasForeignKey(z => z.MealId)
               .OnDelete(DeleteBehavior.NoAction);

            //config for Animal - Meal_Animal one-to-many relationship
            modelBuilder.Entity<Animal>()
               .HasMany(a => a.Meal_Animals)
               .WithOne(z => z.Animal)
               .HasForeignKey(z => z.AnimalId)
               .OnDelete(DeleteBehavior.NoAction);
        }



    }
    /* Demo for EntityConfiguration
        public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
        {
            public void Configure(EntityTypeBuilder<Account> builder)
            {
                builder.ToTable("account");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("id");
                builder.Property(x => x.Username).HasColumnName("username");
                builder.Property(x => x.Password).HasColumnName("password");
                builder.Property(x => x.Email).HasColumnName("email");
                builder.Property(x => x.Phone).HasColumnName("phone");
                builder.Property(x => x.Role).HasColumnName("role");
                builder.Property(x => x.Status).HasColumnName("status");
                builder.Property(x => x.CreatedAt).HasColumnName("created_at");
                builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            }
        }
    */

}
