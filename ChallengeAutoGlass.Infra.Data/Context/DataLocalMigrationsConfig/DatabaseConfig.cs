using System;
namespace ChallengeAutoGlass.Infra.Data.Context.DataLocalMigrationsConfig
{
	public static class DatabaseConfig
    {

        //TODO : Using migrations to perform local tests of the application flow. mslocaldb can be used. The provider used is only the sql server
        //TODO : n production this connection string will not be that of any official service. In a real project, your configuration will be a local developer base for your tests, thus running the migrations
        public const string DATABASE_LOCAL_CONNECTION_STRING = "Server=localhost;Database=autoglass_challenge;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;Trusted_Connection=False;MultipleActiveResultSets=true";

    }
}

