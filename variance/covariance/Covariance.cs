using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;
using csharp_concepts.variance.common.impl;
using csharp_concepts.variance.covariance.api;
using csharp_concepts.variance.covariance.impl;

namespace csharp_concepts.variance.covariance
{
    delegate Repository GetRepoRef();
    delegate NoSQLRepository GetNoSQLRepoRef();
    delegate SQLRepository GetSQLRepoRef();
    public class Covariance
    {
         
        public static Repository GetRepository() {
            var rand = new Random();
            var value = rand.Next(0, 10);
            if (value > 5)
            {
                return new NoSQLRepository();
            }
            else {
                return new SQLRepository();
            }

        }

        public static NoSQLRepository GetNoSQLRepository() {
            return new NoSQLRepository();
        }

        public static SQLRepository GetSQLRepository()
        {
            return new SQLRepository();
        }

        public static void delegates() {
            GetRepoRef getRepoRefInstance = GetRepository;
            GetNoSQLRepoRef getNoSQLRepoRefInstance = GetNoSQLRepository;
            GetSQLRepoRef getSQLRepoRefInstance = GetSQLRepository;

            //any function reference that produces a Repository can be substituted with a function reference which produces a subclass of Repository
            getRepoRefInstance = GetNoSQLRepository;
        }

        public static void containers() {
            IRepositoryProvider<Repository> repositoryProvider = new SQLRepositoryProvider<SQLRepository>();
            IRepositoryProvider<SQLRepository> sqlRepositoryProvider = new SQLRepositoryProvider<SQLRepository>();
            IRepositoryProvider<NoSQLRepository> noSQLRepositoryProvider = new NoSQLRepositoryProvider<NoSQLRepository>();

            //IRepositoryProvider<SQLRepository> is acting like a sub class of IRepositoryProvider<Repository>
            repositoryProvider = sqlRepositoryProvider;
            repositoryProvider = noSQLRepositoryProvider;
        }
    }

   
}
