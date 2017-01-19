namespace YasService.Models.Context
{
    using System.Data.Entity;
    public class YasContext : DbContext, IYasContext
    {
        public YasContext() : base("name=YasDbService")
        {
            Database.SetInitializer<YasContext>(null);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<TeamPermission> TeamPermission { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}