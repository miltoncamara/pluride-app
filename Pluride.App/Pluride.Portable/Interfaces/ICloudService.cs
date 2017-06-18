using Pluride.App.Models;

namespace Pluride.App.Interfaces
{
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;
    }
}
