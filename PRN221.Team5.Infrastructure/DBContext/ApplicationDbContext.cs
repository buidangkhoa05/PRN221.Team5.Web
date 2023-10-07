using PRN221.Team5.Domain.Entity;

namespace Team5.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
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
        public DbSet<User> Users { get; set; }
        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

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
