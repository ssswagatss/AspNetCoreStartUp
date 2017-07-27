using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Interfaces
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Fetches all the Entities of Type T
        /// </summary>
        /// <returns>All entities present as IEnumerable</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Fetches all the Entities of Type T Asynchronously
        /// </summary>
        /// <returns>All entities present as IEnumerable asynchronously</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Fetches all the Entities of Type T depending upon a condition
        /// </summary>
        /// <param name="predicate">Lambda experession representing a conditon</param>
        /// <returns>All entities satisfying the condition as IEnumerable </returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Fetches the no of elements present
        /// </summary>
        /// <param name="predicate">Lambda experession representing a conditon</param>
        /// <returns>An Integer</returns>
        int Count(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Fetches all the Entities of Type T depending upon a condition
        /// </summary>
        /// <param name="filter">Lambda expression for where clause</param>
        /// <param name="orderBy">Lambda expressions for Order by</param>
        /// <param name="includeProperties">comma-delimited list of navigation properties for eager loading</param>
        /// <param name="skip">Skip the No of elements you want to skip</param>
        /// <param name="take">No of elements you want to take, Send 0 if you want all</param>
        /// <returns></returns>
        IEnumerable<T> FindWithInclude(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? skip = null, int? take = null);

        /// <summary>
        /// Returns the first element
        /// </summary>
        /// <param name="filter">Predicate</param>
        /// <returns></returns>
        T FirstOrDefault(
           Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Returns the first element
        /// </summary>
        /// <param name="filter">Predicate</param>
        /// <param name="includeProperties">Include Properties</param>
        /// <returns></returns>
        T FirstOrDefaultWithInclude(
           Expression<Func<T, bool>> filter = null, string includeProperties = "");
        /// <summary>
        /// Add an object of Type T to the dataset
        /// </summary>
        /// <param name="entity">The object that requires to be added</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Removes an object of Type T from the dataset
        /// </summary>
        /// <param name="entity">The object that requires to be removed</param>
        /// <returns></returns>
        T Delete(T entity);

        /// <summary>
        /// Attach an Entity to the data set and changes its entity state to Modified
        /// </summary>
        /// <param name="entity">The object that requires to be edited</param>
        /// <returns>Void</returns>
        void Edit(T entity);


        /// <summary>
        /// Commit the changes to the database
        /// </summary>
        /// <returns>Integer</returns>
        int Save();
    }
}
