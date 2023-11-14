using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain1;

public partial class ZooManagementContext : DbContext
{
    public ZooManagementContext()
    {
    }

    public ZooManagementContext(DbContextOptions<ZooManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalSpecy> AnimalSpecies { get; set; }

    public virtual DbSet<AnimalTraining> AnimalTrainings { get; set; }

    public virtual DbSet<Cage> Cages { get; set; }

    public virtual DbSet<CageAnimal> CageAnimals { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<MealAnimal> MealAnimals { get; set; }

    public virtual DbSet<MealFood> MealFoods { get; set; }

    public virtual DbSet<TraineerProfile> TraineerProfiles { get; set; }

    public virtual DbSet<ZooNews> ZooNews { get; set; }

    public virtual DbSet<ZooSection> ZooSections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ZooManagement;User Id=sa;Password=12345;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Fullname).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasIndex(e => e.SpecieId, "IX_Animals_SpecieId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dob).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

            entity.HasOne(d => d.Specie).WithMany(p => p.Animals).HasForeignKey(d => d.SpecieId);
        });

        modelBuilder.Entity<AnimalSpecy>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<AnimalTraining>(entity =>
        {
            entity.HasIndex(e => e.AnimalId, "IX_AnimalTrainings_AnimalId");

            entity.HasIndex(e => e.TrainerId, "IX_AnimalTrainings_TrainerId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Animal).WithMany(p => p.AnimalTrainings).HasForeignKey(d => d.AnimalId);

            entity.HasOne(d => d.Trainer).WithMany(p => p.AnimalTrainings).HasForeignKey(d => d.TrainerId);
        });

        modelBuilder.Entity<Cage>(entity =>
        {
            entity.HasIndex(e => e.AnimalSpecieId, "IX_Cages_AnimalSpecieId");

            entity.HasIndex(e => e.ZooSectionId, "IX_Cages_ZooSectionId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NumberCage).ValueGeneratedOnAdd();

            entity.HasOne(d => d.AnimalSpecie).WithMany(p => p.Cages)
                .HasForeignKey(d => d.AnimalSpecieId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ZooSection).WithMany(p => p.Cages).HasForeignKey(d => d.ZooSectionId);
        });

        modelBuilder.Entity<CageAnimal>(entity =>
        {
            entity.ToTable("Cage_Animals");

            entity.HasIndex(e => e.AnimalId, "IX_Cage_Animals_AnimalId");

            entity.HasIndex(e => e.CageId, "IX_Cage_Animals_CageId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Animal).WithMany(p => p.CageAnimals)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cage).WithMany(p => p.CageAnimals)
                .HasForeignKey(d => d.CageId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<MealAnimal>(entity =>
        {
            entity.ToTable("Meal_Animals");

            entity.HasIndex(e => e.AnimalId, "IX_Meal_Animals_AnimalId");

            entity.HasIndex(e => e.MealId, "IX_Meal_Animals_MealId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Animal).WithMany(p => p.MealAnimals)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Meal).WithMany(p => p.MealAnimals)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MealFood>(entity =>
        {
            entity.ToTable("Meal_Food");

            entity.HasIndex(e => e.FoodId, "IX_Meal_Food_FoodId");

            entity.HasIndex(e => e.MealId, "IX_Meal_Food_MealId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Food).WithMany(p => p.MealFoods)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Meal).WithMany(p => p.MealFoods)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TraineerProfile>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_TraineerProfiles_AccountId").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Account).WithOne(p => p.TraineerProfile).HasForeignKey<TraineerProfile>(d => d.AccountId);
        });

        modelBuilder.Entity<ZooNews>(entity =>
        {
            entity.HasIndex(e => e.OwnerId, "IX_ZooNews_OwnerId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Owner).WithMany(p => p.ZooNews).HasForeignKey(d => d.OwnerId);
        });

        modelBuilder.Entity<ZooSection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
