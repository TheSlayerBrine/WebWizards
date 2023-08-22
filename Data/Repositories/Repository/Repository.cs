namespace WebWizards.Data.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext dbContext;
        public Repository(AppDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();

        }
        public T Find(int id)
        {
            return dbContext.Set<T>().Find(id); 
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
           dbContext.Set<T>().Add(entity);
        }
    }
}

