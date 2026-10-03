using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyCircle : Shape
	{
		private int _radius;

        public MyCircle() : this(Color.Blue, 0, 0, 50) { }

        public MyCircle(SplashKitSDK.Color clr, float x, float y, int radius) : base(clr)
		{
			_radius = radius;
		}

        public int Radius { get { return _radius; } set { _radius = value; } }

        public override void Draw()
        {
            if (Selected) { DrawOutline(); }
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKitSDK.Color.Black, X, Y, _radius + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }

    }
}

