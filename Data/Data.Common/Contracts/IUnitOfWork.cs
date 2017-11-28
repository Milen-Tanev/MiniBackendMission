namespace Data.Common
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}