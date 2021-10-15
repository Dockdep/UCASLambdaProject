using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;

namespace UCASLambdaServerless.Helpers
{
    public static class ResponseHelper
    {
        public static APIGatewayProxyResponse Ok(string message)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int) HttpStatusCode.OK,
                Body = message,
                Headers = new Dictionary<string, string> {{"Content-Type", "text/plain"}}
            };
        }

        public static APIGatewayProxyResponse NotFound()
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int) HttpStatusCode.NotFound
            };
        }
    }
}