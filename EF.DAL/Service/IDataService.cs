using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF.DAL.Service
{
    public interface IDataService<T>
    {

        /// <summary>
        /// get all elements entities in data base 
        /// </summary>
        /// <returns></returns>

        Task<List<T>> GetALL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Create(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(int id, T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        Task<bool> Delete(int id);
    }
}
