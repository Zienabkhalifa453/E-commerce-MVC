using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Relationships and Cascade Behavior

            // Cart - ApplicationUser Relationship
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.customer)
                .WithMany(u => u.carts)
                .HasForeignKey(c => c.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Order - Payment Relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.payment)
                .WithMany(p => p.orders)
                .HasForeignKey(o => o.Payment_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // OrderItem - Product Relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.product)
                .WithMany(p => p.orderItems)
                .HasForeignKey(oi => oi.Product_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Payment - ApplicationUser Relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.customer)
                .WithMany(c => c.payments)
                .HasForeignKey(p => p.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Shipment - ApplicationUser Relationship
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.customer)
                .WithMany(c => c.shipments)
                .HasForeignKey(s => s.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // WishList - ApplicationUser Relationship
            modelBuilder.Entity<WishList>()
                .HasOne(w => w.customer)
                .WithMany(c => c.wishLists)
                .HasForeignKey(w => w.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction);

            // Product - Category Relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.Category_Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
