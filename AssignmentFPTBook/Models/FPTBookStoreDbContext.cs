using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AssignmentFPTBook.Models
{
    public partial class FPTBookStoreDbContext : DbContext
    {
        public FPTBookStoreDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.AuthorID)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookID)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.AuthorID)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.BookID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
