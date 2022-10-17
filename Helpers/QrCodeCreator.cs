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
    public string GetQrCode()
    {
        var encoder = new QRCodeEncoder();
        var qrCode = encoder.Encode(_settings.Url);
        qrCode.Save(_settings.Path!);
        return _settings.Path!;
    }
}