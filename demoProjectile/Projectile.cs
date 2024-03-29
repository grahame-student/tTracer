﻿using libTracer.Common;

namespace demoProjectile;

internal class Projectile
{
    public TPoint Position { get; }
    public TVector Velocity { get; }

    public Projectile(TPoint position, TVector velocity)
    {
        Position = position;
        Velocity = velocity;
    }
}