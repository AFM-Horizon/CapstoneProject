using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CapstoneProject.DataAccess
{
    //Generics
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/

    //Repository Pattern
    //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

    ///<summary>
    ///The <see cref="IRepository{TEntity,TId}"/> defines the contract that our repositories must adhere to.
    /// Think of it as the blueprint for the "plug" component that the repository implementations use.
    /// <para>
    ///     The <see cref="TEntity"/> is a generic parameter representing the model/class that the repository will end up using
    /// </para>
    /// <para>
    ///     The <seealso cref="TId"/> is a generic parameter representing the id type that the repository will end up using (string, int, etc)
    /// </para>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<TEntity, in TId> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TId id);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
