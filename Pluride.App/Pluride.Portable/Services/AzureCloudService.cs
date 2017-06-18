using Microsoft.WindowsAzure.MobileServices;
using Pluride.App.Interfaces;
using Pluride.App.Models;
using Pluride.App.Portable.Services;

namespace Pluride.App.Services
{
    public class AzureCloudService : ICloudService
    {
        MobileServiceClient client;

        public AzureCloudService()
        {
            client = new MobileServiceClient("http://pluride-api-app.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new AzureCloudTable<T>(client);
        }
    }
}
