using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using url_shortener.Tests.Helpers;
using Xunit;

namespace url_shortener.Tests;

public class SwaggerTests
{
    private readonly WebClient _webClient;

    public SwaggerTests()
    {
        _webClient = new WebClient();
    }
    
    [Fact]
    public async Task PostTest()
    {
        var fullUrl = "https://swagger.io/docs/specification/describing-parameters/";
        var algorithm = SHA256.Create();
        
        var result = await _webClient.PostUrl(fullUrl);

        Assert.Equal((BitConverter.ToInt32(algorithm.ComputeHash(Encoding.UTF8.GetBytes(fullUrl)))).ToString(), result);
    }

    [Fact]
    public async Task GetTest()
    {
        var fullUrl = "https://swagger.io/docs/specification/describing-parameters/";
        
        var shortUrl = await _webClient.PostUrl(fullUrl);
        await _webClient.GetUrl(shortUrl);
    }
}