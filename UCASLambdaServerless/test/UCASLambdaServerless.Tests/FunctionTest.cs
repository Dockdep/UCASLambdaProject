using System.Threading.Tasks;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using UCASLambdaServerless.Functions;

namespace UCASLambdaServerless.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task TestGetMethod()
        {
            GetFunction functions = new GetFunction();


            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();
            var response = await functions.Get(request, context);
            Assert.Equal(200, response.StatusCode);
        }
    }
}