namespace Data.Common
{
    using System.Data.Entity;
    using System.Linq;

    public interface INobelPrizeWinnersDbRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }

        void Add(T entity);
        IQueryable<T> All();
        void Update(T entity);
    }
}