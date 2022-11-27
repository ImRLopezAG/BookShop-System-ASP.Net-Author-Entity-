using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Core {
  public interface IDbFactory {
    DbContext GetDbContext { get; }
  }
}
