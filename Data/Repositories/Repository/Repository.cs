namespace WebWizards.Data.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext dbContext;
        public Repository(AppDbContext context)
        {
            dbContext = context;
        }
        T IRepository<T>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Added(T entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.Find()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

