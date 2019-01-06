using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleOneDDD.Domain.Interfaces
{   
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add2(T obj);
        int SaveChanges();

        T GetById(int id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);


        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        //void Add(TEntity obj);
        //TEntity GetById(Guid id);
        //IQueryable<TEntity> GetAll();
        //void Update(TEntity obj);
        //void Remove(Guid id);
        //int SaveChanges();
    }
}
