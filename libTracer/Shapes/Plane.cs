﻿using System;
using System.Collections.Generic;
using libTracer.Common;
using libTracer.Scene;

namespace libTracer.Shapes;

public class Plane : Shape
{
    protected override Bounds LocalBounds()
    {
        return new Bounds(
            new TPoint(Double.NegativeInfinity, 0, Double.NegativeInfinity),
            new TPoint(Double.PositiveInfinity, 0, Double.PositiveInfinity));
    }

    protected override TVector LocalNormal(TPoint point)
    {
        return new TVector(0, 1, 0);
    }

    protected override IList<Intersection> LocalIntersects(TRay ray)
    {
        var result = new List<Intersection>();
        if (Math.Abs(ray.Direction.Y) < Constants.EPSILON) return result;
        Double t = -ray.Origin.Y / ray.Direction.Y;
        result.Add(new Intersection(t, this));

        return result;
    }
}
