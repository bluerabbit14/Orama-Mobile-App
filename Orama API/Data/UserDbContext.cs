
using Microsoft.EntityFrameworkCore;
using Orama_API.Model.Domain;

namespace Orama_API.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<Users> User { get; set; } = null!;
        public DbSet<Roles> Role { get; set; } = null!;
        public DbSet<PasswordResetTokens> PasswordResetToken { get; set; } = null!;
        public DbSet<UserLogins> UserLogin { get; set; } = null!;
        public DbSet<UserVerifications> UserVerification { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId).ValueGeneratedOnAdd();
                entity.Property(u => u.Email);
                entity.Property(u => u.Phone);
                entity.Property(u => u.Username);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.IsEmailVerified).HasDefaultValue(false);
                entity.Property(u => u.IsPhoneVerified).HasDefaultValue(false);
                entity.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(u => u.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(u => u.RoleId);
                entity.Property(u => u.RoleId).ValueGeneratedOnAdd().UseIdentityColumn(seed:1,increment:1);
                entity.Property(u => u.Name).IsRequired();
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(u => u.LoginId);
                entity.Property(u => u.LoginId).ValueGeneratedOnAdd();
                entity.Property(u => u.UserId);
                entity.Property(u => u.LoginTime).HasDefaultValue("CURRENT_TIMESTAMP");
                entity.Property(u => u.IpAddress);
                entity.Property(u => u.DeviceInfo);
            });

            modelBuilder.Entity<PasswordResetTokens>(entity =>
            {
                entity.HasKey(u => u.ResetId);
                entity.Property(u => u.ResetId).ValueGeneratedOnAdd();
                entity.Property(u => u.UserId);
                entity.Property(u => u.Token).IsRequired();
                entity.Property(u => u.ExpiresAt);
                entity.Property(u => u.IsUsed).HasDefaultValue(false);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserVerifications>(entity =>
            {
                entity.HasKey(u => u.VerificationId);
                entity.Property(u => u.VerificationId).ValueGeneratedOnAdd();
                entity.Property(u => u.UserId);
                entity.Property(u => u.ContactType);
                entity.Property(u => u.ContactValue);
                entity.Property(u => u.VerificationCode);
                entity.Property(u => u.CodeType);
                entity.Property(u => u.Purpose);
                entity.Property(u => u.ExpiresAt);
                entity.Property(u => u.IsUsed).HasDefaultValue(false);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
