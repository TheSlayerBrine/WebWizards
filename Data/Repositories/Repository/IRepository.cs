namespace WebWizards.Data.Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        void Added(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find();
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
