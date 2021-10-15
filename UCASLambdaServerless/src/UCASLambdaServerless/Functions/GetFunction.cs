using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UCASLambdaServerless.Base;
using UCASLambdaServerless.Helpers;
using UCASLambdaServerless.Repository;

namespace UCASLambdaServerless.Functions
{
    public class GetFunction : BaseLambdaFunction
    {
        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway with all data row from DynamoDB 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The API Gateway response with all data.</returns>
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get All Request\n");
            var repo = new DataRepository();
            var result = await repo.All();
            return ResponseHelper.Ok(JsonConvert.SerializeObject(result));
        }
    }
}