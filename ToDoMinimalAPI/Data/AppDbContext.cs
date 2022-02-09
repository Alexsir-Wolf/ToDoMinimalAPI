using Microsoft.EntityFrameworkCore;

namespace ToDoMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {   
        public DbSet<Todo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=RED-;Initial Catalog=TODO;Integrated " +
                "Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
