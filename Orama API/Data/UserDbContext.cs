
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
                entity.Property(u => u.UpdatedAt)
                      .HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.IsActive)
                      .HasDefaultValue(true);

                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict); // optional: prevent cascade delete
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.RoleId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(seed: 1, increment: 1); ; // For IDENTITY(1,1)
                entity.Property(r => r.Name)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.HasIndex(r => r.Name)
                      .IsUnique();
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasKey(l => l.LoginId);
                entity.Property(l => l.LoginId)
                      .HasDefaultValueSql("NEWID()");
                entity.Property(l => l.LoginTime)
                      .IsRequired();
                entity.Property(l => l.IpAddress)
                      .HasMaxLength(45);
                entity.Property(l => l.DeviceInfo)
                      .HasMaxLength(255);

                entity.HasOne(l => l.User)
                      .WithMany() // or .WithMany(u => u.UserLogins) if you add a navigation property in `User`
                      .HasForeignKey(l => l.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PasswordResetTokens>(entity =>
            {
                entity.ToTable("PasswordResetTokens");
                entity.HasKey(p => p.ResetId);
                entity.Property(p => p.ResetId)
                      .HasDefaultValueSql("NEWID()");
                entity.Property(p => p.Token)
                      .IsRequired()
                      .HasMaxLength(512);
                entity.Property(p => p.ExpiresAt)
                      .IsRequired();
                entity.Property(p => p.IsUsed)
                      .HasDefaultValue(false);
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(p => p.User)
                      .WithMany(u => u.PasswordResetTokens) // or WithMany(u => u.PasswordResetTokens)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserVerifications>(entity =>
            {
                entity.ToTable("UserVerifications");
                entity.HasKey(v => v.VerificationId);
                entity.Property(v => v.VerificationId)
                      .HasDefaultValueSql("NEWID()");
                entity.Property(v => v.ContactType)
                      .IsRequired()
                      .HasMaxLength(10);
                entity.Property(v => v.ContactValue)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(v => v.VerificationCode)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(v => v.CodeType)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(v => v.Purpose)
                      .IsRequired()
                      .HasMaxLength(30);
                entity.Property(v => v.ExpiresAt)
                      .IsRequired();
                entity.Property(v => v.IsUsed)
                      .HasDefaultValue(false);
                entity.Property(v => v.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(v => v.User)
                      .WithMany(u => u.UserVerifications) // Or .WithMany(u => u.UserVerifications) if you want navigation
                      .HasForeignKey(v => v.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
