using DbUp;
using Newtonsoft.Json;
using url_shortener.Entities;

namespace url_shortener.Migrations;

public static class Migrations
{
    public static void RunMigrations()
    {
        var json = File.ReadAllText("appsettings.json");
        var connectionString = (JsonConvert.DeserializeObject<Settings>(json)).ConnectionString;

        var upgrader =
            DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsFromFileSystem(@"Migrations/Scripts/")
                .Build();

        upgrader.PerformUpgrade();
    }
}