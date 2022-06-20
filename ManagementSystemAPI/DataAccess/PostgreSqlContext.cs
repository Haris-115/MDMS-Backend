using ManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystemAPI.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Distributors> distributors { get; set; }
        public DbSet<Manufactures> manufactures { get; set; }
        public DbSet<Medstores> medstores { get; set; }
        public DbSet<Medicines> medicines { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Orderitems> orderitems { get; set; }
        public DbSet<Stocks> stocks { get; set; }
        public DbSet<Users> users { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Manufactures>()
        //     .HasOne(p => p.distributors_id);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Distributors>()
        //        .Property(p => p.distributors_id)
        //        .ValueGeneratedOnAdd();
        //    modelBuilder.Entity<Manufactures>()
        //        .Property(p => p.manufactures_id)
        //        .ValueGeneratedOnAdd();
        //}
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}