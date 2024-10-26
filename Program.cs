using System.Drawing;
using SoftRasterizer;

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var filePath = Path.Combine(desktopPath, "img.png");

var img = new PngImage(128, 128);
img.Clear(Color.Black);

Console.WriteLine("Loading wire mesh...");

Console.WriteLine("Drawing wire mesh...");


Console.WriteLine("Saving image...");

img.ToFile(filePath);

Console.WriteLine("Done!");
