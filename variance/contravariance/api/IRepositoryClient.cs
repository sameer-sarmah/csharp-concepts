using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;

namespace csharp_concepts.variance.contravariance.api
{
    public interface IRepositoryClient<in T> where T : Repository,new()
    {
        public void consume(T repository);
    }
}
