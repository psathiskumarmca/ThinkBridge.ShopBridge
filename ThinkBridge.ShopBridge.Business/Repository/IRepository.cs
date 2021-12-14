using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridge.ShopBridge.Business.Repository
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll(); // we can build on top of it to get more filtered data
        Task<T> GetById(int id); //get by ID
        Task<T> GetById(long id); //get by ID
        void Add(T entity);//add new
        void Update(T entity);//update
        void Delete(T entity);//delete entity
        void Delete(int id);//delete by id
    }
}
