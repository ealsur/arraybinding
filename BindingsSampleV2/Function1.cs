
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BindingsSample
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] MyClass[] inputDocuments
            , ILogger log)
        {
            log.LogInformation($"Received {inputDocuments.Length} documents");

            return new OkObjectResult($"Received {inputDocuments.Length} documents");
        }
    }

    public class MyClass
    {
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }
}
