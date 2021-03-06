﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository.Common;
using VehicleApp.Repository.Models;

namespace VehicleApp.Repository
{
    public class Repository : IRepository

    {
        #region Properties

        protected VehicleDbContext DbContext { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        #endregion Properties


        #region Constructors

        public Repository(VehicleDbContext db, IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (db == null)
            {
                throw new ArgumentException("DbContext");
            }
            DbContext = db;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        #endregion Constructors


        #region Methods

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        /// <summary>
        /// Gets all entities from the database async.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual Task<List<T>> GetAsync<T>() where T : class
        {
            return DbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Gets the entity by Id async.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Task<T> GetByIDAsync<T>(int id) where T : class
        {
            return DbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Creates an instance of the type T async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<T> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            await DbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the entity of the type T async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the entity of the type T async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the entity by ID async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsync<T>(int id) where T : class
        {
            var entity = await GetByIDAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified id not found.");
            }
            return await DeleteAsync<T>(entity);
        }

        /// <summary>
        /// Gets the entities from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> GetWhere<T>() where T : class
        {
            return DbContext.Set<T>();
        }

        #endregion Methods
    }
}
