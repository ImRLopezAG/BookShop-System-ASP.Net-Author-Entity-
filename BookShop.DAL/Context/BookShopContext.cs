using BookShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Context {
  public class BookShopContext : DbContext {
    public BookShopContext(DbContextOptions<BookShopContext> options) : base(options) { }
    public DbSet<Author> Authors { get; set; }


  }
}
