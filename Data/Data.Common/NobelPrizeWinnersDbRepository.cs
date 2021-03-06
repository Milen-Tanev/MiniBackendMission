﻿namespace Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class NobelPrizeWinnersDbRepository<T> : INobelPrizeWinnersDbRepository<T>
        where T : class
    {
        public NobelPrizeWinnersDbRepository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException("The DbContext in NobelPrizeWinnersDbRepository cannot be null.");
            this.DbSet = this.Context.Set<T>();
        }

        internal DbContext Context { get; private set; }

        public DbSet<T> DbSet { get; }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }
    }
}
