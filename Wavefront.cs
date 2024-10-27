using System.Numerics;

namespace SoftRasterizer;

public class Wavefront
{
    private List<Vec3> _vertices = [];
    private List<Face> _faces = [];

    private void AddVertex(Vec3 vertex)
    {
        _vertices.Add(vertex);
    }

    private void AddFace(Face face)
    {
        _faces.Add(face);
    }

    private void ParseVertex(string[] data)
    {
        var x = float.Parse(data[0]);
        var y = float.Parse(data[1]);
        var z = float.Parse(data[2]);
        
        AddVertex(new Vec3(x, y, z));
    }

    private void ParseFace(string[] data)
    {
        foreach (var point in data)
        {
            Console.WriteLine(point);
        }
    }

    public static Wavefront? FromFile(string filename)
    {
        try
        {
            var obj = new Wavefront();
            
            foreach (var line in File.ReadLines(filename))
            {
                var data = line.Split(' ');
                var type = data[0];
                switch (type)
                {
                    case "v":
                        obj.ParseVertex(data[1..]);
                        break;
                    case "f":
                        obj.ParseFace(data[1..]);
                        break;
                    default:
                        continue;
                }
            }

            return obj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}