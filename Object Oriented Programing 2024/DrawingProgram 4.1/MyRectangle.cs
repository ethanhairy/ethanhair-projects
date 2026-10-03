using System;
using System.Drawing;
using SplashKitSDK;

namespace DrawingProgram
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public MyRectangle() : this(SplashKitSDK.Color.Green, 0, 0, 100, 100) { }

        public MyRectangle(SplashKitSDK.Color clr, float x, float y, int width, int height): base (clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;  
        }

        public int Height { get { return _height; } set { _height = value; } }
        public int Width { get { return _width; } set { _width = value; } }

        public override void Draw()
        {
            if (Selected) { DrawOutline(); }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, Width, Height));
        }
    }
}

