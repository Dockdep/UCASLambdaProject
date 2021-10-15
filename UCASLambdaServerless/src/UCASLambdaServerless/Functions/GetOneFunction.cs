using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using UCASLambdaServerless.Base;
using UCASLambdaServerless.Helpers;
using UCASLambdaServerless.Repository;

namespace UCASLambdaServerless.Functions
{
    public class GetOneFunction : BaseLambdaFunction
    {
        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway with one row from DynamoDB,
        /// require {dataId} query param
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The API Gateway response with one particular row.</returns>
        public async Task<APIGatewayProxyResponse> GetOne(APIGatewayProxyRequest request, ILambdaContext context)
        {
            if (request.PathParameters == null || !request.PathParameters.ContainsKey("dataId")) return ResponseHelper.NotFound();

            var dataId = Guid.Parse(request.PathParameters["dataId"]);
            var repo = new DataRepository();
            var result = await repo.Single(dataId);
            return result != null ? ResponseHelper.Ok(JsonConvert.SerializeObject(result)) : ResponseHelper.NotFound();
        }
    }
}