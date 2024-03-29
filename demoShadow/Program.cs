﻿using libTracer.Scene;
using System;
using System.Collections.Generic;
using libTracer.Common;
using libTracer.Shapes;

namespace demoShadow;

internal class Program
{
    static void Main(String[] args)
    {
        var rayOrigin = new TPoint(0, 0, -5);
        const Double wallZ = 10;
        const Double wallSize = 7;

        const Int32 size = 500;
        var canvas = new Canvas(size, size);
        Double pixelSize = wallSize / canvas.Width;
        const Double halfWall = wallSize / 2;

        var sphereColour = new TColour(1, 0, 0);
        var sphere = new Sphere();

        foreach (Pixel pixel in canvas.Pixels)
        {
            Double worldY = -halfWall + pixelSize * pixel.Y;
            Double worldX = -halfWall + pixelSize * pixel.X;

            var position = new TPoint(worldX, worldY, wallZ);

            var ray = new TRay(rayOrigin, (position - rayOrigin).Normalise());
            IList<Intersection> intersection = sphere.Intersects(ray);
            if (Intersection.Hit(intersection) == null) continue;

            canvas.SetPixel(pixel.X, pixel.Y, sphereColour);
        }

        var writer = new BitmapWriter();
        writer.SaveToBitmap(canvas, @"sphere.png");
    }
}