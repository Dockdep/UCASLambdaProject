using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using UCASLambdaServerless.DTO;
using UCASLambdaServerless.Models;

namespace UCASLambdaServerless.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public DataRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }

        
        public async Task<DataModel> Single(Guid readerId)
        {
            return await _context.LoadAsync<DataModel>(readerId);
        }

        public async Task<IEnumerable<DataModel>> All()
        {
            return await _context
                .ScanAsync<DataModel>(null)
                .GetRemainingAsync();
        
        }

        public async Task<DataModel> Add(DtoDataModel entity)
        {
            var model = new DataModel()
            {
                Id = Guid.NewGuid(),
                Text = entity.Text
            };
            
            await _context.SaveAsync<DataModel>(model);
            
            return model;
        }

        public async Task Remove(Guid readerId)
        {
            await _context.DeleteAsync<DataModel>(readerId);
        }

        public async Task Update(Guid dataId, DtoDataModel entity)
        {
            var reader = await Single(dataId);
            reader.Text = entity.Text;
            
            await _context.SaveAsync(reader);
        }
    }
}