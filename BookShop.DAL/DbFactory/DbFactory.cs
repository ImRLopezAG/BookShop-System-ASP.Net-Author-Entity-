using BookShop.DAL.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop.DAL.DbFactory {
  public class DbFactory : IDbFactory, IDisposable {
    private readonly DbContext _dbContext;
    private bool isDisposed;

    public DbFactory(DbContext dbContext) => _dbContext = dbContext;

    public DbContext GetDbContext => this._dbContext;

    public void Dispose() {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing) {
      if (!isDisposed && disposing) {
        if (this._dbContext != null) {
          this._dbContext.Dispose();
        }

      }
      isDisposed = true;
    }

  }
}
