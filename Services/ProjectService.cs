using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Portfolio.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Services
{
    public class ProjectService : IProjectService
    {
        private Container _container;

        public ProjectService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync<T>(T data) where T : IDIndexable
        {
            await _container.CreateItemAsync(data, new PartitionKey(data.Id));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string queryString) where T : class
        {
            List<T> results = new List<T>();
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<T> GetAsync<T>(string id) where T : class
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateAsync<T>(string id, T item) where T : class
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }
        public async Task DeleteAsync<T>(string id) where T : class
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }
    }
}
