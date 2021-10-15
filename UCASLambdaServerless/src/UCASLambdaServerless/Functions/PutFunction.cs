using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using UCASLambdaServerless.Base;
using UCASLambdaServerless.DTO;
using UCASLambdaServerless.Helpers;
using UCASLambdaServerless.Models;
using UCASLambdaServerless.Repository;

namespace UCASLambdaServerless.Functions
{
    public class PutFunction : BaseLambdaFunction
    {
        /// <summary>
        /// A Lambda function to put data in dynamoDb
        /// require {DtoDataModel} json object in request body
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The API Gateway response.</returns>
        public async Task<APIGatewayProxyResponse> PutOne(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var data = JsonConvert.DeserializeObject<DtoDataModel>(request.Body);
            
            if (data == null) return ResponseHelper.NotFound();

            var repo = new DataRepository();
            var result = await repo.Add(data);
            
            return ResponseHelper.Ok(JsonConvert.SerializeObject(result));

        }
    }
}