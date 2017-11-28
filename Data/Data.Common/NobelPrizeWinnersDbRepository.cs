namespace Data.Common
{
    using System.Data.Entity;
    using System.Linq;

    public class NobelPrizeWinnersDbRepository<T> : INobelPrizeWinnersDbRepository<T>
        where T : class
    {
        public NobelPrizeWinnersDbRepository(DbContext context)
        {
            this.Context = context;
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
            this.DbSet.Attach(entity);
            var entry = this.Context.Entry(entity);
            
            entry.State = EntityState.Modified;
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }
    }
}
