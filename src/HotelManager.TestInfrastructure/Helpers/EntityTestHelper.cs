using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HotelManager.TestInfrastructure.Helpers
{
    public static class EntityTestHelper
    {
        public static SqliteConnection GenerateNewConnection(bool? suppressForeignKeyEnforcement = false)
        {
            string connectionString = (suppressForeignKeyEnforcement == true) ? ";Foreign Keys=False" : string.Empty;

            SqliteConnection sqliteConnection = new SqliteConnection("DataSource=:memory:" + connectionString);

            sqliteConnection.Open();

            return sqliteConnection;
        }

        public static TContext GetDbContext<TContext>(SqliteConnection connection) where TContext : DbContext
        {
            DbContextOptionsBuilder<TContext> dbOptions = GetDbOptions<TContext>(connection);

            ConstructorInfo constructor = typeof(TContext).GetConstructor([typeof(DbContextOptions<TContext>)]) ?? throw new Exception("Nenhum construtor encontrado para o contexto especificado.");

            return (TContext)constructor.Invoke([dbOptions.Options]);
        }

        public static DbContextOptionsBuilder<TContext> GetDbOptions<TContext>(SqliteConnection? connectionInput = null) where TContext : DbContext
        {
            SqliteConnection connection = connectionInput ?? GenerateNewConnection(true);

            DbContextOptionsBuilder<TContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<TContext>();

            dbContextOptionsBuilder.UseSqlite(connection, delegate (SqliteDbContextOptionsBuilder c)
            {
                c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            return dbContextOptionsBuilder;
        }
    }
}