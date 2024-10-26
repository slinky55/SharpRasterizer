using System.Drawing;
using SkiaSharp;

namespace SoftRasterizer;

public class PngImage (int width, int height)
{
    private int Width { get; } = width;
    private int Height { get; } = height;

    private readonly SKBitmap _imageData = new(width, height);

    public void WritePixel(int x, int y, Color c)
    {
        var color = new SKColor(c.R, c.G, c.B, c.A);
        _imageData.SetPixel(x, y, color);
    }

    public void Clear(Color c)
    {
        var color = new SKColor(c.R, c.G, c.B, c.A);
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                _imageData.SetPixel(x, y, color);
            }
        }
    }

    public void ToFile(string filename)
    {
        using var img = SKImage.FromBitmap(_imageData);
        using var encoded = img.Encode(SKEncodedImageFormat.Png, 100);
        using var file = File.OpenWrite(filename);
        
        encoded.SaveTo(file);
    }
}