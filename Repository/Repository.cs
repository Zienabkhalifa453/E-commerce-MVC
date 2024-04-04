using E_commerce.Models;
using E_commerce_MVC.interfaces;

namespace E_commerce.Repository
{
    public class Repository<T> : IRepository<T> where T : class, ISoftDeletable
    {

        protected Context context;
        public Repository(Context context)
        {
            this.context = context;
        }

        public void insert(T entity)
        {
            context.Set<T>().Add(entity);

        }
        public void delete(T entity)
        {

            entity.IsDeleted = true;
            update(entity);


        }

        public void update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public ICollection<T> GetAll()
        {

            return context.Set<T>().ToList();
        }


        //find object by name ,id or etc.....
        public T Get(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public int save()
        {
            return context.SaveChanges();
        }


    }

}
