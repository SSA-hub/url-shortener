using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using url_shortener.Entities;
using url_shortener.Repositories;

namespace url_shortener.Helpers;

public class UrlShortener
{
    private readonly UrlShortenerRepository _urlShortenerRepository;
    private readonly Settings _settings;
    
    public UrlShortener()
    {
        var json = File.ReadAllText("appsettings.json");
        _settings = JsonConvert.DeserializeObject<Settings>(json);
        _urlShortenerRepository = new UrlShortenerRepository(_settings.ConnectionString);
    }

    public async Task<string> InsertAsync(string fullUrl)
    {
        var algorithm = SHA256.Create();
        var url = new Url
        {
            FullUrl = fullUrl,
            ShortUrl = BitConverter.ToInt32(algorithm.ComputeHash(Encoding.UTF8.GetBytes(fullUrl)))
        };
        await _urlShortenerRepository.InsertAsync(url);
        if (_settings.ForRobot)
            return url.ShortUrl.ToString();
        return _settings.RedirectUrl + url.ShortUrl;
    }

    public async Task<string> GetAsync(int shortUrl)
    {
        return await _urlShortenerRepository.GetAsync(shortUrl);
    }
}