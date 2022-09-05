// <copyright file="RepositoryBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Database.Abstract.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Database.Framework
{
    public abstract class RepositoryBase<TEntity> : IRepository
        where TEntity : class, IEntity
    {
        protected DbContext storageContext;
        protected DbSet<TEntity> dbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.storageContext = storageContext as DbContext;
            this.dbSet = this.storageContext.Set<TEntity>();
        }
    }
}