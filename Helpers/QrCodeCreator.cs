using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json;
using url_shortener.Entities;

namespace url_shortener.Helpers;

public class QrCodeCreator
{
    private readonly QrSettings _settings;

    public QrCodeCreator()
    {
        var json = File.ReadAllText("appsettings.json");
        _settings = JsonConvert.DeserializeObject<QrSettings>(json);
    }
    public Bitmap GetQrCode()
    {
        var encoder = new QRCodeEncoder();
        var qrCode = encoder.Encode("https://ironsoftware.com/csharp/barcode");
        if (_settings.Save)
            qrCode.Save(_settings.Path!);
        return qrCode;
    }
}