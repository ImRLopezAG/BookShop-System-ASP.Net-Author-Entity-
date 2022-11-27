using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookShop.DAL.Core {
  public interface IBaseRepository<TEntity> where TEntity : class {
    void Save(TEntity entity);
    void Save(TEntity[] entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    TEntity GetEntity(int entityId);
    bool Exists(Expression<Func<TEntity, bool>> filter);
    IEnumerable<TEntity> GetEntities();
    void ExecutableProcedure(string procedureCommand, params SqlParameter[] sqlParams);
  }
}
