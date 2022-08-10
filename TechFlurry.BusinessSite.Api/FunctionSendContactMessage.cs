using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using TechFlurry.BusinessSite.Api.Infrastructure;
using TechFlurry.BusinessSite.Models;

namespace TechFlurry.BusinessSite.Api
{
    public static class FunctionSendContactMessage
    {
        [FunctionName("SendContactMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SendContactMessage function processing a request.");
            var dbClient = await DbClientSingleton.Instance.Value;
            var container = dbClient.GetMessagesContainer();
            log.LogInformation("created db client");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation($"request data: {requestBody}");
            var data = JsonConvert.DeserializeObject<ContactMessageModel>(requestBody);
            log.LogInformation("Processed request data properly");
            try
            {
                log.LogInformation("Writing the data to db");
                data.Id = Guid.NewGuid();
                var item = await container.CreateItemAsync(data);
                log.LogInformation($"Data has been written with etag: {item.ETag}");
            }
            catch (Exception e)
            {
                log.LogError($"Data writing failed: {e.Message}");
            }

            string responseMessage = "Thank you for contacting us! We will reach you shortly";
            log.LogInformation("Exiting the SendContactMessage Function");
            return new OkObjectResult(responseMessage);
        }
    }
}
