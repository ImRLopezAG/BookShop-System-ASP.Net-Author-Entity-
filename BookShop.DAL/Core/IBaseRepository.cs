using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookShop.DAL.Core {
  public interface IBaseRepository<TEntity> where TEntity : class {
    void Save(TEntity Entity);
    void Save(TEntity[] Entity);
    void Update(TEntity Entity);
    void Remove(TEntity Entity);
    TEntity GetEntity(int EntityId);
    bool Exists(Expression<Func<TEntity, bool>> Filter);
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    void ExecutableProcedure(string procedureCommand, params SqlParameter[] sqlParams);
  }
}
