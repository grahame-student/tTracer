﻿using System;
using libTracer.Common;
using NUnit.Framework;

namespace TestLibTracer.Common;

internal class TestTPoint
{
    private const Double SOME_X = 1.2;
    private const Double SOME_Y = 3.4;
    private const Double SOME_Z = 5.6;

    private TPoint _point;

    [Test]
    public void Constructor_SetsX_ToPassedInValue()
    {
        _point = new TPoint(SOME_X, 0, 0);

        Assert.That(_point.X, Is.EqualTo(SOME_X));
    }

    [Test]
    public void Constructor_SetsY_ToPassedInValue()
    {
        _point = new TPoint(0, SOME_Y, 0);

        Assert.That(_point.Y, Is.EqualTo(SOME_Y));
    }

    [Test]
    public void Constructor_SetsZ_ToPassedInValue()
    {
        _point = new TPoint(0, 0, SOME_Z);

        Assert.That(_point.Z, Is.EqualTo(SOME_Z));
    }

    [Test]
    public void Constructor_SetsW_To1()
    {
        _point = new TPoint(0, 0, SOME_Z);

        Assert.That(_point.W, Is.EqualTo(1));
    }

    [Test]
    public void AddingVectorToPoint_Returns_Point()
    {
        var point1 = new TPoint(0, 0, 0);
        var vector2 = new TVector(0, 0, 0);

        Assert.That(point1 + vector2, Is.InstanceOf<TPoint>());
    }

    [Test]
    public void AddingVectorToPoint_Adds_XComponents()
    {
        var point1 = new TPoint(1, 0, 0);
        var vector2 = new TVector(2, 0, 0);

        TPoint point3 = point1 + vector2;

        Assert.That(point3.X, Is.EqualTo(3));
    }

    [Test]
    public void AddingVectorToPoint_Adds_YComponents()
    {
        var point1 = new TPoint(0, 2, 0);
        var vector2 = new TVector(0, 4, 0);

        TPoint point3 = point1 + vector2;

        Assert.That(point3.Y, Is.EqualTo(6));
    }

    [Test]
    public void AddingVectorToPoint_Adds_ZComponents()
    {
        var point1 = new TPoint(0, 0, 4);
        var vector2 = new TVector(0, 0, 8);

        TPoint point3 = point1 + vector2;

        Assert.That(point3.Z, Is.EqualTo(12));
    }

    [Test]
    public void SubtractingPointFromPoint_Returns_Vector()
    {
        var point1 = new TPoint(0, 0, 0);
        var point2 = new TPoint(0, 0, 0);

        Assert.That(point1 - point2, Is.InstanceOf<TVector>());
    }

    [Test]
    public void SubtractingPointFromPoint_Subtracts_XComponents()
    {
        var point1 = new TPoint(3, 0, 0);
        var point2 = new TPoint(1, 0, 0);

        TVector point3 = point1 - point2;

        Assert.That(point3.X, Is.EqualTo(2));
    }

    [Test]
    public void SubtractingPointFromPoint_Subtracts_YComponents()
    {
        var point1 = new TPoint(0, 5, 0);
        var point2 = new TPoint(0, 2, 0);

        TVector point3 = point1 - point2;

        Assert.That(point3.Y, Is.EqualTo(3));
    }

    [Test]
    public void SubtractingPointFromPoint_Subtracts_ZComponents()
    {
        var point1 = new TPoint(0, 0, 9);
        var point2 = new TPoint(0, 0, 1);

        TVector point3 = point1 - point2;

        Assert.That(point3.Z, Is.EqualTo(8));
    }

    [Test]
    public void SubtractingVectorFromPoint_Returns_Point()
    {
        var point1 = new TPoint(0, 0, 0);
        var vector2 = new TVector(0, 0, 0);

        Assert.That(point1 - vector2, Is.InstanceOf<TPoint>());
    }

    [Test]
    public void SubtractingVectorFromPoint_Subtracts_XComponents()
    {
        var point1 = new TPoint(3, 0, 0);
        var vector2 = new TVector(1, 0, 0);

        TPoint point3 = point1 - vector2;

        Assert.That(point3.X, Is.EqualTo(2));
    }

    [Test]
    public void SubtractingVectorFromPoint_Subtracts_YComponents()
    {
        var point1 = new TPoint(0, 5, 0);
        var vector2 = new TVector(0, 2, 0);

        TPoint point3 = point1 - vector2;

        Assert.That(point3.Y, Is.EqualTo(3));
    }

    [Test]
    public void SubtractingVectorFromPoint_Subtracts_ZComponents()
    {
        var point1 = new TPoint(0, 0, 9);
        var vector2 = new TVector(0, 0, 1);

        TPoint point3 = point1 - vector2;

        Assert.That(point3.Z, Is.EqualTo(8));
    }

    [Test]
    public void Equals_ReturnsTrue_WhenXEqualToOtherX()
    {
        var point1 = new TPoint(1, 0, 0);
        var point2 = new TPoint(1, 0, 0);

        Assert.That(point1, Is.EqualTo(point2));
    }

    [Test]
    public void Equals_ReturnsTrue_WhenYEqualToOtherY()
    {
        var point1 = new TPoint(0, 2, 0);
        var point2 = new TPoint(0, 2, 0);

        Assert.That(point1, Is.EqualTo(point2));
    }

    [Test]
    public void Equals_ReturnsTrue_WhenZEqualToOtherZ()
    {
        var point1 = new TPoint(0, 0, 3);
        var point2 = new TPoint(0, 0, 3);

        Assert.That(point1, Is.EqualTo(point2));
    }

    [Test]
    public void Equals_ReturnsFalse_WhenOtherIsObjectAndNull()
    {
        var point1 = new TPoint(0, 0, 0);
        Object point2 = null;

        Assert.That(point1.Equals(point2), Is.False);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenOtherIsObject()
    {
        var point1 = new TPoint(0, 0, 0);
        Object point2 = new TPoint(0, 0, 0);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenOtherIsObjectAndSameReference()
    {
        var point1 = new TPoint(0, 0, 0);
        Object point2 = point1;

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsFalse_WhenOtherIsPointAndNull()
    {
        var point1 = new TPoint(0, 0, 0);
        TPoint point2 = null;

        Assert.That(point1.Equals(point2), Is.False);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenOtherIsPointAndSameReference()
    {
        var point1 = new TPoint(0, 0, 0);
        TPoint point2 = point1;

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenXPositiveInfinite()
    {
        var point1 = new TPoint(Double.PositiveInfinity, 0, 0);
        var point2 = new TPoint(Double.PositiveInfinity, 0, 0);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenXNegativeInfinite()
    {
        var point1 = new TPoint(Double.NegativeInfinity, 0, 0);
        var point2 = new TPoint(Double.NegativeInfinity, 0, 0);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenYPositiveInfinite()
    {
        var point1 = new TPoint(0, Double.PositiveInfinity, 0);
        var point2 = new TPoint(0, Double.PositiveInfinity, 0);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenYNegativeInfinite()
    {
        var point1 = new TPoint(0, Double.NegativeInfinity, 0);
        var point2 = new TPoint(0, Double.NegativeInfinity, 0);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenZPositiveInfinite()
    {
        var point1 = new TPoint(0, 0, Double.PositiveInfinity);
        var point2 = new TPoint(0, 0, Double.PositiveInfinity);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Equals_ReturnsTrue_WhenZNegativeInfinite()
    {
        var point1 = new TPoint(0, 0, Double.NegativeInfinity);
        var point2 = new TPoint(0, 0, Double.NegativeInfinity);

        Assert.That(point1.Equals(point2), Is.True);
    }

    [Test]
    public void Hashcode_ReturnsSameValue_WhenSetToSameValues()
    {
        var point1 = new TPoint(2, 3, 4);
        var point2 = new TPoint(2, 3, 4);

        Assert.That(point1.GetHashCode(), Is.EqualTo(point2.GetHashCode()));
    }
}