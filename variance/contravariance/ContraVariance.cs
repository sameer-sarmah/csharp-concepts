using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;
using csharp_concepts.variance.common.impl;
using csharp_concepts.variance.contravariance.api;
using csharp_concepts.variance.contravariance.impl;
using csharp_concepts.variance.covariance.api;
using csharp_concepts.variance.covariance.impl;

namespace csharp_concepts.variance.contravariance
{
    delegate void ConsumeRepoRef(Repository repository);
    delegate void ConsumeNoSQLRepoRef(NoSQLRepository noSQLRepository);
    delegate void ConsumeSQLRepoRef(SQLRepository sqlRepository);
    public class ContraVariance
    {
        public static void ConsumeRepository(Repository repository)
        {
            repository.read();
        }

        public static void ConsumeNoSQLRepository(NoSQLRepository noSQLRepository)
        {
            noSQLRepository.read();
        }

        public static void ConsumeSQLRepository(SQLRepository sqlRepository)
        {
            sqlRepository.read();
        }

        public static void delegates()
        {
            ConsumeRepoRef consumeRepoRefInstance = ConsumeRepository;
            ConsumeNoSQLRepoRef consumeNoSQLRepoRefInstance = ConsumeNoSQLRepository;
            ConsumeSQLRepoRef consumeSQLRepoRefInstance = ConsumeSQLRepository;
            Repository noSQLRepository = new NoSQLRepository();
            Repository sqlRepository = new SQLRepository();
            consumeRepoRefInstance(noSQLRepository);
            consumeRepoRefInstance(sqlRepository);

            consumeNoSQLRepoRefInstance(new NoSQLRepository());
            consumeSQLRepoRefInstance(new SQLRepository());
            //consumeSQLRepoRefInstance expects an instance of SQLRepository but actually refers to a method which takes any Repository 
            consumeSQLRepoRefInstance = ConsumeRepository;
            //consumeNoSQLRepoRefInstance expects an instance of NoSQLRepository but actually refers to a method which takes any Repository 
            consumeNoSQLRepoRefInstance = ConsumeRepository;
        }

        public static void containers()
        {
            IRepositoryClient<Repository> repositoryClient = new SQLRepositoryClient<Repository>();
            IRepositoryClient<SQLRepository> sqlRepositoryClient = new SQLRepositoryClient<SQLRepository>();
            IRepositoryClient<NoSQLRepository> noSQLRepositoryClient = new NoSQLRepositoryClient<NoSQLRepository>();

            repositoryClient.consume(new SQLRepository());
            repositoryClient.consume(new NoSQLRepository());

            sqlRepositoryClient.consume(new SQLRepository());
            noSQLRepositoryClient.consume(new NoSQLRepository());

            //sqlRepositoryClient.consume expects an instance of SQLRepository but actually refers to a method which takes any Repository
            sqlRepositoryClient = repositoryClient;
            //noSQLRepositoryClient.consume expects an instance of NoSQLRepository but actually refers to a method which takes any Repository
            noSQLRepositoryClient = repositoryClient;
        }
    }
}
