using BookShop.DAL.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookShop.DAL.Core {
  public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class {
    private readonly BookShopContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(BookShopContext context) {
      _context = context;
      _dbSet = _context.Set<TEntity>();
    }

    public virtual void ExecutableProcedure(string procedureCommand, params SqlParameter[] sqlParams) =>
      this._context.Database.ExecuteSqlRaw(procedureCommand, sqlParams);
    public virtual bool Exists(Expression<Func<TEntity, bool>> filter) => this._dbSet.Any(filter);

    public IEnumerable<TEntity> GetAll() => this._dbSet.AsEnumerable();

    public TEntity GetById(int EntityId) => this._dbSet.Find(EntityId);

    public virtual TEntity GetEntity(int EntityId) => this._dbSet.Find(EntityId);
    public virtual void Remove(TEntity Entity) => this._dbSet.Remove(Entity);
    public virtual void Save(TEntity Entity) => this._dbSet.Add(Entity);
    public virtual void Save(TEntity[] Entities) => this._dbSet.AddRange(Entities);
    public virtual void Update(TEntity Entity) {
      var Entry = this._context.Entry(Entity);
      Entry.State = EntityState.Modified;
    }
  }
}

