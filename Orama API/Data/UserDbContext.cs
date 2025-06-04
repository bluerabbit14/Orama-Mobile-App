
using Microsoft.EntityFrameworkCore;
using Orama_API.Model.Domain;

namespace Orama_API.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        //each represent a table in database...
        public DbSet<Users> User { get; set; } = null!;
        public DbSet<Subscriptions> Subscription { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId)
                      .HasDefaultValueSql("NEWID()");

                entity.Property(u => u.Email)
                      .HasMaxLength(255);
                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.Phone)
                      .HasMaxLength(20);
                entity.HasIndex(u => u.Phone)
                      .IsUnique();

                entity.Property(u => u.UserName)
                      .HasMaxLength(100);

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(512);

                entity.Property(u => u.IsEmailVerified)
                      .HasDefaultValue(false);

                entity.Property(u => u.IsPhoneVerified)
                      .HasDefaultValue(false);

                entity.Property(u => u.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(u => u.LastUpdated)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(u => u.IsActive)
                      .HasDefaultValue(true);

                entity.Property(u => u.Role)
                      .HasMaxLength(20)
                      .HasDefaultValue("user");

                entity.Property(u => u.SubscriptionId)
                      .IsRequired(false);

                entity.HasOne(u => u.Subscription)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.SubscriptionId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.ToTable("Subscriptions");
                entity.HasKey(s => s.SubscriptionId);
                entity.Property(s => s.SubscriptionId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(seed: 1000, increment: 1); ; // For IDENTITY(1000,1)

                entity.Property(s => s.SubscriptionPlan)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(s => s.SubscriptionPlan)
                      .IsUnique();

                entity.Property(s => s.Description)
                      .HasMaxLength(500);

                entity.Property(s => s.Price)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(s => s.CreatedAt)
                       .HasDefaultValueSql("GETDATE()");

                entity.Property(s => s.LastUpdated)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(s => s.IsActive)
                      .HasDefaultValue(true);

                entity.Property(s => s.ActiveUsers)
                      .HasDefaultValue(0); // Default active users

                entity.Property(s => s.MaxUsers)
                      .HasDefaultValue(10); // Default max users
                 
                entity.Property(s => s.MaxStorage)
                      .HasDefaultValue(1000); // in MB
            });

        }
    }
}
