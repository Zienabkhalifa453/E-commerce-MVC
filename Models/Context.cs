using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cart> cart { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Shipment> shipment { get; set; }
        public DbSet<WishList> wishList { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<customer>()
                .HasKey(c => c.id);



            // Configure Relationships and Cascade Behavior
            modelBuilder.Entity<Order>()
                .HasOne(o => o.payment)
                .WithMany(p => p.orders)
                .HasForeignKey(o => o.Payment_Id)
                .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.NoAction

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.product)
                .WithMany(p => p.orderItems)
                .HasForeignKey(oi => oi.Product_Id)
                .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.NoAction

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.customer)
                .WithMany(c => c.payments)
                .HasForeignKey(p => p.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.NoAction

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.customer)
                .WithMany(c => c.shipments)
                .HasForeignKey(s => s.Customer_Id)
                .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.NoAction
        }
    }
}
