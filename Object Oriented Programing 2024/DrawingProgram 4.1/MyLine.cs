using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyLine : Shape
	{
        private int _length;

        public MyLine() : this(SplashKitSDK.Color.Yellow, 100) { }

        public MyLine(SplashKitSDK.Color clr, int length) : base(clr)
		{
            _length = length;
		}

        public int Length { get { return _length; } set { _length = Length; } }

        public override void Draw()
        {
            if (Selected) { DrawOutline(); }
            SplashKit.DrawLine(Color, X, Y, X + Length, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKitSDK.Color.Black, X, Y, 4);
            SplashKit.FillCircle(SplashKitSDK.Color.Black, X + Length, Y, 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X + Length, Y));
        }
    }
}

