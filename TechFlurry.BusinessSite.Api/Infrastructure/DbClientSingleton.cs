using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace TechFlurry.BusinessSite.Api.Infrastructure
{
    internal class DbClientSingleton
    {
        private CosmosClient cosmosClient;
        private DatabaseResponse db;
        private Container messsagesContainer;

        private DbClientSingleton()
        {
            cosmosClient = new CosmosClient("AccountEndpoint=https://businesssite-db.documents.azure.com:443/;AccountKey=rEWEpFmLBSLxRmHaIDWYGbUHGxqCHyBqYzb5FHq2Y3zS8xWdxN61LnojiwO3YHET8322WeWz1ifjQzYDeHrUTQ==;");

        }

        private async Task InitClient()
        {
            db = await cosmosClient.CreateDatabaseIfNotExistsAsync("businesssite_db");
        }


        public Container GetMessagesContainer()
        {
            messsagesContainer ??= cosmosClient.GetContainer(db.Database.Id, "Messages");
            return messsagesContainer;
        }


        public static Lazy<Task<DbClientSingleton>> Instance => new(async () =>
            {
                var dbClient = new DbClientSingleton();
                await dbClient.InitClient();
                return dbClient;
            });
    }
}
