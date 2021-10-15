using System;
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
    public class ChangeFunction : BaseLambdaFunction
    {
        /// <summary>
        /// A Lambda function to patch data in dynamoDb
        /// require {{DtoDataModel}} json object in request body and {dataId} query param
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>The API Gateway response.</returns>
        public async Task<APIGatewayProxyResponse> Change(APIGatewayProxyRequest request, ILambdaContext context)
        {
            if (request.PathParameters == null || !request.PathParameters.ContainsKey("dataId"))
                return ResponseHelper.NotFound();
            
            var dataId = Guid.Parse(request.PathParameters["dataId"]);
       
            context.Logger.LogLine($"Change data for {dataId}\n");
            
            var data = JsonConvert.DeserializeObject<DtoDataModel>(request.Body);

            if (data == null) return ResponseHelper.NotFound();
            context.Logger.LogLine($"New data {request.Body}\n");
            var repo = new DataRepository();
            await repo.Update(dataId, data);
            return ResponseHelper.Ok($"Data for entity {dataId} was changed\n");

        }
    }
}