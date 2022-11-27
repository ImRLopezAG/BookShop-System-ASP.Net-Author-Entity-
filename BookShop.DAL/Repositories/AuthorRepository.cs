using BookShop.DAL.Context;
using BookShop.DAL.Core;
using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
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

    public void Save(Author entity) {
      if (this.context.Authors.Any(cb => cb.Id == entity.Id)) {
        throw new Exceptions.AuthorDataException("El Autor se encuentra Registrado");
      } else {
        this.context.Authors.Add(entity);
      }
    }

    public void Save(Author[] entity) {
      if (entity.Any())
        base.Save(entity);
      else
        throw new Exceptions.AuthorDataException("Author is null");

      base.Save(entity);
    }

    public void Update(Author entity) {
      throw new NotImplementedException();
    }

    IEnumerable<Author> IBaseRepository<Author>.GetEntities() => base.GetEntities().Where(cb => !cb.IsDeleted);
  }
}

