using System.Drawing;
using MessagingToolkit.QRCode.Codec;

namespace url_shortener.Helpers;

public static class QrCodeCreator
{
    public static Bitmap GetQrCode()
    {
        var encoder = new QRCodeEncoder();
        var qrCode = encoder.Encode("https://ironsoftware.com/csharp/barcode");
        qrCode.Save("qrcode.bmp");
        return qrCode;
    }
}