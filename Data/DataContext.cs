using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data; 

public class DataContext : DbContext {
    public DbSet<User> users { get; set; }
    public DbSet<Role> roles { get; set; }
    public DbSet<RoleUser> roleUsers { get; set; }
    public DbSet<Book> books { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<Customer> clients { get; set; }
    public DbSet<Delivery> deliveries { get; set; }
    public DbSet<PriceChange> priceChanges { get; set; }
    public DbSet<Publisher> publishers { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<PurchaseItem> purchaseItems { get; set; }
    public DbSet<Store> stores { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        // Database.Migrate();
    }

    public DataContext() { }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //     optionsBuilder.UseNpgsql(optionsBuilder.Con);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // modelBuilder.Entity<Store>().HasMany<Book>().WithOne(p => p.id);
    }
}