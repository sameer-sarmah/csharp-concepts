using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;
using csharp_concepts.variance.covariance.api;

namespace csharp_concepts.variance.covariance.impl
{
   public class NoSQLRepositoryProvider<T> : IRepositoryProvider<T> where T : Repository, new()
    {
        public T getRepository()
        {
            return new T();
        }
    }
}
