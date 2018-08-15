using System;

namespace Contracts
{
    public interface IApiCalls<R, T>
    {
        System.Threading.Tasks.Task<T> Get(R request);
        //T Get(R request);
        T Post(R request);
    }
}
