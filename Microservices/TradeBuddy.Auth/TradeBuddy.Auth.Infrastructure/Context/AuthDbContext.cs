using Microsoft.EntityFrameworkCore;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Infrastructure.Context
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تعریف کلیدهای اصلی برای هر موجودیت
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Permission>().HasKey(p => p.Id);
            modelBuilder.Entity<UserRole>().HasKey(ur => ur.Id);
            modelBuilder.Entity<RolePermission>().HasKey(rp => rp.Id);

            // تنظیم روابط بین UserRole و User
            modelBuilder.Entity<UserRole>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ur => ur.UserId);

            // تنظیم روابط بین UserRole و Role
            modelBuilder.Entity<UserRole>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);

            // تنظیم روابط بین RolePermission و Role
            modelBuilder.Entity<RolePermission>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(rp => rp.RoleId);

            // تنظیم روابط بین RolePermission و Permission
            modelBuilder.Entity<RolePermission>()
                .HasOne<Permission>()
                .WithMany()
                .HasForeignKey(rp => rp.PermissionId);

            // پیکربندی Address به عنوان نوع وابسته
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.FirstName);

            modelBuilder.Entity<User>()
            .OwnsOne(u => u.LastName);

            modelBuilder.Entity<User>()
            .OwnsOne(u => u.Phone);

            modelBuilder.Entity<User>()
            .OwnsOne(u => u.Username);

            // پیکربندی Email به عنوان نوع وابسته
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Email);

            // اطمینان از اینکه ویژگی‌های مجازی برای لیزی لودینگ وجود دارند
            modelBuilder.Entity<Role>()
                .Navigation(r => r.Permissions)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
