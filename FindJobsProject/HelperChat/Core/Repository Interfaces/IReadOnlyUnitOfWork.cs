using System;
using System.Collections.Generic;
using System.Text;

namespace FindJobsProject.HelperChat.Core.Repository_Interfaces
{
    public interface IReadOnlyUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
