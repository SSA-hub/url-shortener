using Dommel;
using Npgsql;
using url_shortener.Entities;

namespace url_shortener.Repositories;

public class UrlShortenerRepository
{
    private readonly string? _connectionString;

    public UrlShortenerRepository(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task InsertAsync(Url url)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.InsertAsync(url);
    }
    
    public async Task<string> GetAsync(int shortUrl)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        var result = (await connection.GetAllAsync<Url>()).First(url => url.ShortUrl == shortUrl);
        return result.FullUrl;
    }
}