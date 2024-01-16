using Npgsql;

namespace Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry =0) {

            int retryForAvailability = retry.Value;

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrated Postgres database!");
                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection,
                    };
                    command.CommandText = "DROP TABLE IF EXISTS Coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = @"Create Table Coupon(
                        Id SERIAL PRIMARY KEY NOT NULL,
                        ProductName VARCHAR(24) NOT NULL,
                        Description TEXT,
                        Amount INT
                    )";
                    command.ExecuteNonQuery();
                    logger.LogInformation("Migrated Postgres database!");

                }
                catch(NpgsqlException ex)
                {
                    logger.LogError("An error occurred while migrating the postgres database!");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }

            return host;
        }
    }
}
