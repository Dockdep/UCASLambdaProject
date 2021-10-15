using System;
using Amazon.DynamoDBv2.DataModel;

namespace UCASLambdaServerless.Models
{
    [DynamoDBTable("ucas-data")]
    public class DataModel
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}