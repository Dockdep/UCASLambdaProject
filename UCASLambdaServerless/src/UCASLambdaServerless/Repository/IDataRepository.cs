using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UCASLambdaServerless.DTO;
using UCASLambdaServerless.Models;

namespace UCASLambdaServerless.Repository
{
    public interface IDataRepository
    {
        Task<DataModel> Single(Guid readerId);
        Task<IEnumerable<DataModel>> All();
        Task<DataModel> Add(DtoDataModel entity);
        Task Remove(Guid dataId);
        Task Update(Guid dataId, DtoDataModel entity);
    }
}