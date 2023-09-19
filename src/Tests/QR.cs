using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using ZXing;
using ZXing.Common;

namespace MenosRelato;

public class QR(ITestOutputHelper output)
{
    [Fact]
    public void Run()
    {
        var data = Guid.NewGuid().ToString();
        var writer = new BarcodeWriterGeneric
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = 300,
                Height = 300,
                Margin = 0
            }
        };

        var qrmatrix = writer.Encode("https://chota");
        
        var border = 80;
        var radius = 40;        
        int margin = border / 2;

        var qr = new Image<Rgba32>(qrmatrix.Width + border, qrmatrix.Height + border);
        qr.Paint(Color.White).Mutate(x => x.ApplyCorners(radius));

        for (var x = 0; x < qrmatrix.Width; x++)
        {
            for (var y = 0; y < qrmatrix.Height; y++)
            {
                qr[x + margin, y + margin] = qrmatrix[x, y] ? Color.Black : Color.White;
            }
        }

        var image = new Image<Rgba32>(qrmatrix.Width + border + border, qrmatrix.Height + border + border);
        
        image.Paint(Rgba32.ParseHex("#6C4C99"))
            .Mutate(x => x.ApplyCorners(radius));

        // Insert QR into colored frame
        image.Mutate(x => x.DrawImage(qr, new Point(margin, margin), 
            new GraphicsOptions 
            { 
                AlphaCompositionMode = PixelAlphaCompositionMode.SrcOver 
            }));

        var path = new FileInfo("qr.png");
        image.SaveAsPng(path.FullName);

        Process.Start(new ProcessStartInfo(path.FullName) { UseShellExecute = true });
    }
}
