using BookShop.DAL.Context;
using BookShop.DAL.Core;
using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.DAL.Repositories {
  public class AuthorRepository : BaseRepository<Author>, IAuthorRepository {
    private readonly BookShopContext context;
    private readonly ILogger<AuthorRepository> logger;
    public AuthorRepository(BookShopContext context, ILogger<AuthorRepository> logger) : base(context) {
      this.context = context;
      this.logger = logger;
    }
    public Author GetEntity(int EntityId) => this.context.Authors.Find(EntityId);

    public Author GetById(int EntityId) => this.context.Authors.OrderByDescending(cb => cb.Id).FirstOrDefault();

    IEnumerable<Author> IBaseRepository<Author>.GetAll() => this.context.Authors.OrderByDescending(cb => cb.CreationDate).ToList();
    public void Save(Author entity) {
      this.context.Authors.Add(entity);
      this.context.SaveChanges();
    }
    public void Save(Author[] entity) {
      this.context.Authors.AddRange(entity);
      this.context.SaveChanges();
    }
    public void Update(Author entity) {
      this.context.Authors.Update(entity);
      this.context.SaveChanges();
    }
    public void Remove(Author entity) {
      this.context.Authors.Remove(entity);
      this.context.SaveChanges();
    }
  }
}
