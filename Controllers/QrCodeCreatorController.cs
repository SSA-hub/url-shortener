using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Helpers;

namespace url_shortener.Controllers;

[ApiController]
[Route("[controller]")]
public class QrCodeCreatorController : ControllerBase
{
    private readonly ILogger<QrCodeCreatorController> _logger;
    
    public QrCodeCreatorController(ILogger<QrCodeCreatorController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "CreateQrCode")]
    public Bitmap CreateQrCode()
    {
        _logger.LogTrace("Creating QR-code");
        return QrCodeCreator.GetQrCode();
    }
}