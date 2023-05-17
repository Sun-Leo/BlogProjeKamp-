using Microsoft.EntityFrameworkCore;

namespace BlogProjeKampıAPI.DAL
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=CoreBlogAPIDb;integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
