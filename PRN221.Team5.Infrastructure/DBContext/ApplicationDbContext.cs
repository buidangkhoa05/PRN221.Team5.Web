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
            optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection);
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSet
        private DbSet<Account> Accounts { get; set; }
        private DbSet<ZooNews> ZooNews { get; set; }
        private DbSet<Animal> Animals { get; set; }
        private DbSet<AnimalSpecie> AnimalSpecies { get; set; }
        private DbSet<AnimalGroup> AnimalGroups { get; set; }
        private DbSet<ZooSection> ZooSections { get; set; }
        private DbSet<Cage> Cages { get; set; }
        private DbSet<TraineerProfile> TraineerProfiles { get; set; }
        private DbSet<Cage_Animal> Cage_Animals { get; set; }
        private DbSet<Food> Foods { get; set; }
        private DbSet<FoodType> FoodTypes { get; set; }
        private DbSet<Meal> Meals { get; set; }
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

            //config for AnimalSpecie - Animal one-to-many relationship
            modelBuilder.Entity<AnimalSpecie>()
               .HasMany(a => a.Animals)
               .WithOne(z => z.Specie)
               .HasForeignKey(z => z.SpecieId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for AnimalGroup - Animal one-to-many relationship
            modelBuilder.Entity<AnimalGroup>()
               .HasMany(a => a.Animals)
               .WithOne(z => z.Group)
               .HasForeignKey(z => z.GroupId)
               .OnDelete(DeleteBehavior.SetNull)
               .IsRequired(false);

            //config for Animal - TraineerProfile one-to-many relationship
            modelBuilder.Entity<Animal>()
               .HasMany(a => a.TraineerProfiles)
               .WithOne(z => z.Animal)
               .HasForeignKey(z => z.AnimalId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for Account - TraineerProfile one-to-many relationship
            modelBuilder.Entity<Account>()
              .HasMany(a => a.TraineerProfiles)
              .WithOne(z => z.Traineer)
              .HasForeignKey(z => z.TraineerId)
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
               .OnDelete(DeleteBehavior.Cascade);

            //config for FoodTye - Food one-to-many relationship
            modelBuilder.Entity<FoodType>()
               .HasMany(a => a.Foods)
               .WithOne(z => z.Type)
               .HasForeignKey(z => z.TypeId)
               .OnDelete(DeleteBehavior.Cascade);

            //config for Meal - Animal one-to-many relationship
            modelBuilder.Entity<Meal>()
               .HasMany(a => a.Animals)
               .WithOne(z => z.Meal)
               .HasForeignKey(z => z.MealId)
               .OnDelete(DeleteBehavior.NoAction);

            //config for Meal - AnimalGroup one-to-many relationship
            modelBuilder.Entity<Meal>()
               .HasMany(a => a.AnimalGroups)
               .WithOne(z => z.Meal)
               .HasForeignKey(z => z.MealId)
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
