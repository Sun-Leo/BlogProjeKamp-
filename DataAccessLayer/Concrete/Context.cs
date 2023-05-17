using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=CoreBlog; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(x => x.WriterSender)
                .HasForeignKey(x => x.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(y => y.ReceiverUser)
                .WithMany(y => y.WriterReciver)
                .HasForeignKey(y => y.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<City> Cities  { get; set; }
        public DbSet<NewsLetter> NewsLetters  { get; set; }
        public DbSet<BlogRayting> BlogRaytings  { get; set; }
        public DbSet<Natification> Natifications  { get; set; }
        public DbSet<Message> Messages  { get; set; }
        public DbSet<Message2> Message2s  { get; set; }
        public DbSet<Admin> Admins  { get; set; }
    }
}
