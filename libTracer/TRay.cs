using System;

namespace libTracer
{
    public class TRay
    {
        public TPoint Origin { get; }
        public TVector Direction { get; }

        public TRay(TPoint origin, TVector direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public TPoint Position(Single time)
        {
            return Origin + Direction * time;
        }

        public TRay Transform(TMatrix translation)
        {
            return new TRay(translation * Origin, translation * Direction);
        }
    }
}