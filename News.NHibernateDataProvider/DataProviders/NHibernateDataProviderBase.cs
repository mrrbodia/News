﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using NHibernate;
using News.NHibernateDataProvider.NHibernateCore;

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
    }
}