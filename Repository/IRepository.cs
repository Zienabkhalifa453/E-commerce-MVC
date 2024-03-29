using E_commerce.Models;

namespace E_commerce.Repository
{
    public interface IRepository<T> where T : class 
    {

        public void insert(T entity);  
     
        public void delete(T entity);
     

        public void update(T entity);
       
        public ICollection<T> GetAll();
      


        //find and thing name ,id and etc.....
        public T Get(Func<T, bool> predicate);
       

        public int save();
       
    }
}