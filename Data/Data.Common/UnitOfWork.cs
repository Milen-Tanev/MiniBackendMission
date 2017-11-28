namespace Data.Common
{
    using System;
    using System.Data.Entity;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException("The DbContext in UnitOfWork cannot be null.");
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
