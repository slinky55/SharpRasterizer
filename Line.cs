using System.Drawing;

namespace SoftRasterizer;

// Implementation of Bresenham's Line Drawing Algorithm
public class Line
{
    public static void Draw(
        int x0, int y0, int x1, int y1,
        PngImage img,
        Color c
    )
    {
        var dx = Math.Abs(x1 - x0);
        var dy = Math.Abs(y1 - y0);

        if (dx > dy)
        {
            DrawH(x0, y0, x1, y1, img, c);
        }
        else
        {
            DrawV(x0, y0, x1, y1, img, c);
        }
    }

    private static void DrawH(
        int x0, int y0, int x1, int y1,
        PngImage img,
        Color c
    )
    {
        if (x0 > x1)
        {
            (x0, x1) = (x1, x0);
            (y0, y1) = (y1, y0);
        }
        
        var dx = x1 - x0;
        var dy = y1 - y0;

        int dir;
        if (dy < 0)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }

        dy *= dir;
        
        var d = 2 * dy - dx;
        var y = y0;

        for (var x = x0; x < x1; ++x)
        {
            img.WritePixel(x, y, c);

            if (d >= 0)
            {
                y += dir;
                d -= 2 * dx;
            }

            d += 2 * dy;
        }
    }
    
    private static void DrawV(
        int x0, int y0, int x1, int y1,
        PngImage img,
        Color c
    )
    {
        if (y0 > y1)
        {
            (x0, x1) = (x1, x0);
            (y0, y1) = (y1, y0);
        }
        
        var dx = x1 - x0;
        var dy = y1 - y0;

        int dir;
        if (dx < 0)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }

        dx *= dir;
        
        var d = 2 * dx - dy;
        var x = x0;

        for (var y = y0; y < y1; ++y)
        {
            img.WritePixel(x, y, c);

            if (d >= 0)
            {
                x += dir;
                d -= 2 * dy;
            }

            d += 2 * dx;
        }
    }
}