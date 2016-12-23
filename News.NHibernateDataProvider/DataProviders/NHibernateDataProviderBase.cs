using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using NHibernate;
using News.NHibernateDataProvider.NHibernateCore;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernateDataProviderBase<TEntity> where TEntity : BaseModel
    {
        private ISession CreateSession()
        {
            return Helper.OpenSession();
        }

        protected T Execute<T>(Func<ISession, T> func)
        {
            using (var session = CreateSession())
            {
                return func(session);
            }
        }

        protected void Execute(Action<ISession> action)
        {
            using (var session = CreateSession())
            {
                try
                {
                    action(session);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public virtual TEntity Get(string id)
        {
            return Execute(session =>
            {
                using (var translation = session.BeginTransaction())
                {
                    return session.Get<TEntity>(id);
                }
            });
        }

        public virtual void Create(TEntity model)
        {
            Execute(session =>
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(model);
                    transaction.Commit();
                }
            });
        }

        public virtual void Update(TEntity model)
        {
            Execute(session =>
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(model);
                    transaction.Commit();
                }
            });
        }

        public virtual void Delete(string id)
        {
            Execute(session =>
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(session.Load(typeof(TEntity), id));
                    transaction.Commit();
                }

            });
        }

        public virtual IList<TEntity> GetList()
        {
            return Execute(session =>
            {
                var listTEntity = session.Query<TEntity>().ToList();
                return listTEntity;
            });
        }

        public virtual IList<TEntity> GetListByField(string field, string value)
        {
            IList<TEntity> result = new List<TEntity>();

            var key = String.Format("{0}-{1}-{2}/{3}", System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TEntity).Name, field, value);

            Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(TEntity));
                criteria.Add(Restrictions.Eq(field, value));
                result = criteria.List<TEntity>();
            });
            return result;
        }

        public virtual TEntity GetByField(string field, string value)
        {
            TEntity result = null;

            var key = string.Format("{0}-{1}-{2}/{3}", System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TEntity).Name, field, value);

            Execute(session =>
            {
                var criteria = session.CreateCriteria(typeof(TEntity));
                criteria.Add(Restrictions.Eq(field, value));
                result = criteria.UniqueResult<TEntity>();
            });

            return result;
        }
    }
}
