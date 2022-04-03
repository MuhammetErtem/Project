using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;


namespace Project.DAL.DbContexts
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> opt):base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(ho => ho.Brand).WithMany(wm => wm.Products).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SubCategory>().HasOne(ho => ho.Category).WithMany(wm => wm.SubCategories).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, NameSurname = "Muhammet Ertem", MailAddress = "Muhammet@gmail.com", Password = "202cb962ac59075b964b07152d234b70", LastDate = DateTime.Now, LastIPNo = "1" });

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogPicture> BlogPicture { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalPicture> AnimalPicture { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Admin> Admin { get; set; }



    }
}
