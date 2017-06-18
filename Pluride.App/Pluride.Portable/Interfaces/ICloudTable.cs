using Pluride.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pluride.App.Interfaces
{
    public interface ICloudTable<T> where T : TableData
    {
        Task<T> CreateItemAsync(T item);
        Task<T> ReadItemAsync(string id);
        Task<T> UpdateItemAsync(T item);
        Task DeleteItemAsync(T item);

        Task<ICollection<T>> ReadAllItemsAsync();
    }
}
