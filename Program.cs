using System.Drawing;
using SoftRasterizer;

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var outputFilePath = Path.Combine(desktopPath, "img.png");

var objFilePath = Path.Combine(desktopPath, "cube.obj");

var obj = Wavefront.FromFile(objFilePath)!;
