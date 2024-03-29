﻿using System;
using libTracer.Common;
using libTracer.Shapes;

namespace libTracer.Scene;

public class Computations
{
    public Double Time { get; set; }
    public Shape Object { get; set; }
    public TPoint Point { get; set; }
    public TPoint OverPoint { get; set; }
    public TPoint UnderPoint { get; set; }
    public TVector EyeV { get; set; }
    public TVector NormalV { get; set; }
    public TVector ReflectV { get; set; }
    public Boolean Inside { get; set; }
    public Double N1 { get; set; }
    public Double N2 { get; set; }
}