using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ContactMessageModel>(requestBody);
            name = data.Name;

            string responseMessage = !string.IsNullOrEmpty(name)
                ? JsonConvert.SerializeObject(data)
                : $"This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
