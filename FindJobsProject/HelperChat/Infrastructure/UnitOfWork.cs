
using FindJobsProject.Database;
using FindJobsProject.HelperChat.Core.Repository_Interfaces;
using FindJobsProject.HelperChat.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindJobsProject.HelperChat.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FindJobsContext simpleChatDbContext;



        public UnitOfWork(FindJobsContext simpleChatDbContext)
        {
            this.simpleChatDbContext = simpleChatDbContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new RepositoryBase<TEntity>(this.simpleChatDbContext);
        }

        public void SaveChanges()
        {
            //this.RunBeforeSave(this.dbContextScope);
            this.simpleChatDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //this.RunBeforeSave(this.dbContextScope);
            await this.simpleChatDbContext.SaveChangesAsync(cancellationToken);
        }

        //protected virtual void RunBeforeSave(IDbContextScope currentDbContextScope)
        //{
        //}

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.simpleChatDbContext.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
