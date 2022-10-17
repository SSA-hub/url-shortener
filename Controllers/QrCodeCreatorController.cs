using Microsoft.AspNetCore.Mvc;
using url_shortener.Helpers;

namespace url_shortener.Controllers;

[ApiController]
[Route("[controller]")]
public class QrCodeCreatorController : ControllerBase
{
    private readonly ILogger<QrCodeCreatorController> _logger;
    private readonly QrCodeCreator _creator;
    
    public QrCodeCreatorController(ILogger<QrCodeCreatorController> logger)
    {
        _logger = logger;
        _creator = new QrCodeCreator();
    }
    
    [HttpGet(Name = "CreateQrCode")]
    public string CreateQrCode()
    {
        _logger.LogTrace("Creating QR-code");
        return _creator.GetQrCode();
    }
}