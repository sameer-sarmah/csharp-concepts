using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;
using csharp_concepts.variance.contravariance.api;

namespace csharp_concepts.variance.contravariance.impl
{
    public class SQLRepositoryClient<T> : IRepositoryClient<T> where T : Repository, new()
    {
        public void consume(T repository)
        {
            repository.read();
        }
    }
}
