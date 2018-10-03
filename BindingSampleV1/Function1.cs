using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace BindingSampleV1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] MyClass[] inputDocuments,
            TraceWriter log)
        {
            log.Info($"Received {inputDocuments.Length} documents");

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class MyClass
    {
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }
}
