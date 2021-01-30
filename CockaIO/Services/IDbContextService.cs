using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace CockaIO.Services
{
    public interface IDbContextService
    {
        IQueryable<T> GetAllEntities<T>() where T : class;

        T GetById<T>(int id) where T : class;

        bool CreateEntity<T>(T entity) where T : class;

        bool UpdateEntity<T>(T entity) where T : class;

        bool DeleteEntity<T>(T entity) where T : class;

        void SaveChanges();

    }
}
