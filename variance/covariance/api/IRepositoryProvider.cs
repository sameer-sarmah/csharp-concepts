using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;

namespace csharp_concepts.variance.covariance.api
{
    interface IRepositoryProvider<out T> where T : Repository,new()
    {
        public T getRepository();
    }
}
