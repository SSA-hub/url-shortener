using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace url_shortener.Tests.Helpers;

public class WebClient
{
    private static readonly JsonSerializerOptions? JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    private readonly HttpClient _httpClient;
    private static readonly Encoding LocalEncoding = Encoding.UTF8;

    public WebClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7280/swagger/index.html#/");
    }

    public async Task<string?> PostUrl(string fullUrl)
    {
        var response = await _httpClient.PostAsync($"/UrlShortener?fullUrl={fullUrl}", null);
        response.EnsureSuccessStatusCode();
        var memoryStream = new System.IO.MemoryStream();
        await response.Content.CopyToAsync(memoryStream);
        return LocalEncoding.GetString(memoryStream.ToArray());
    }

    public async Task GetUrl(string? shortUrl)
    {
        var response = await _httpClient.GetAsync($"/UrlShortener?shortUrl={shortUrl}");
        response.EnsureSuccessStatusCode();
    }

    public async Task GetQrCode()
    {
        var response = await _httpClient.GetAsync("/QrCodeCreator");
        response.EnsureSuccessStatusCode();
    }
}