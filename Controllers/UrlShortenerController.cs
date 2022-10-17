using System.Net;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Helpers;

namespace url_shortener.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly ILogger<UrlShortenerController> _logger;
    private readonly UrlShortener _urlShortener;
    
    public UrlShortenerController(ILogger<UrlShortenerController> logger)
    {
        _logger = logger;
        _urlShortener = new UrlShortener();
        Migrations.Migrations.RunMigrations();
    }

    [HttpGet(Name = "GetFullUrl")]
    public async Task<RedirectResult> Get(int shortUrl)
    {
        _logger.LogTrace("Get full url for {0}", shortUrl);
        var fullUrl = await _urlShortener.GetAsync(shortUrl);
        return Redirect(WebUtility.HtmlDecode(fullUrl));
    }

    [HttpPost(Name = "CreateShortUrl")]
    public async Task<string> Post(string fullUrl)
    {
        _logger.LogTrace("Create short url for {0}", fullUrl);
        return await _urlShortener.InsertAsync(fullUrl);
    }
}