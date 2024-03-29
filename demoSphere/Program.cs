﻿using libTracer.Common;
using libTracer.Scene;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoSphere;

internal class Program
{
    static void Main(String[] args)
    {
        var world = new DemoWorld(new TPoint(0, 0, -5), 10, 7);

        const Int32 size = 500;
        var canvas = new Canvas(size, size);
        Double pixelSize = world.WallSize / canvas.Width;

        Parallel.ForEach(canvas.Pixels, pixel => RenderPixel(world, pixelSize, pixel, canvas));

        var writer = new BitmapWriter();
        writer.SaveToBitmap(canvas, @"sphere.png");
    }

    private static void RenderPixel(DemoWorld world, Double pixelSize, Pixel pixel, Canvas canvas)
    {
        Double worldY = -world.HalfWall + pixelSize * pixel.Y;
        Double worldX = -world.HalfWall + pixelSize * pixel.X;

        var position = new TPoint(worldX, worldY, world.WallZ);

        var ray = new TRay(world.RayOrigin, (position - world.RayOrigin).Normalise());
        IList<Intersection> intersection = world.Sphere.Intersects(ray);
        Intersection hit = Intersection.Hit(intersection);
        if (hit == null) return;

        TPoint point = ray.Position(hit.Time);
        TVector normal = hit.Shape.Normal(point);
        TVector eye = -ray.Direction;

        TColour colour = hit.Shape.Material.Lighting(hit.Shape, world.Light, point, eye, normal, false);
        canvas.SetPixel(pixel.X, pixel.Y, colour);
    }
}