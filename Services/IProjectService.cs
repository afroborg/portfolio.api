using Portfolio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(string queryString) where T : class;
        Task<T> GetAsync<T>(string id) where T : class;

        Task AddAsync<T>(T data) where T : IDIndexable;
        Task UpdateAsync<T>(string id, T item) where T : class;
        Task DeleteAsync<T>(string id) where T : class;
    }
}
