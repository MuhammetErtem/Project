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
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Modellerin birbirine bağlandığı yer.
        {
            modelBuilder.Entity<Distinct>().HasOne(ho => ho.City).WithMany(wm => wm.Distincts).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Order>().HasIndex(hi => hi.OrderNumber).IsUnique(true);
            modelBuilder.Entity<Product>().HasOne(ho => ho.Brand).WithMany(wm => wm.Products).HasForeignKey(b=>b.BrandID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Comment>().HasOne(ho => ho.Blog).WithMany(wm => wm.Comments).HasForeignKey(b=>b.BlogID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<SubCategory>().HasOne(ho => ho.Category).WithMany(wm => wm.SubCategories).HasForeignKey(b => b.CategoryID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, NameSurname = "Muhammet Ertem", MailAddress = "Muhammet@gmail.com", Password = "202cb962ac59075b964b07152d234b70", LastDate = DateTime.Now, LastIPNo = "1" });

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalPicture> AnimalPicture { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Distinct> Distinct { get; set; }
        public DbSet<PriceCargo> PriceCargo { get; set; }



    }
}
