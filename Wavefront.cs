using System.Numerics;

namespace SoftRasterizer;

public class Wavefront
{
    private List<Vec3> _vertices = [];
    private List<Vec3> _normals = [];
    private List<Face> _faces = [];

    private void AddVertex(Vec3 vertex)
    {
        _vertices.Add(vertex);
    }

    private void AddNormal(Vec3 normal)
    {
        _normals.Add(normal);
    }

    private void AddFace(Face face)
    {
        _faces.Add(face);
    }

    private void ParseVertex(string line)
    {
        var tokens = line.Split(' ');
    }

    private void ParseFace(string line)
    {
        var tokens = line.Split(' ');
    }

    public static Wavefront? FromFile(string filename)
    {
        try
        {
            var obj = new Wavefront();
            foreach (var line in File.ReadLines(filename))
            {
                var type = line[0];
                
                switch (type)
                {
                    case 'v':
                        var data = line.Substring(1, line.Length).TrimStart();
                        obj.ParseVertex(data);
                        break;
                    case 'f':
                        
                        break;
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