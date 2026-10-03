using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Shape 
    {
        public SplashKitSDK.Color _color;
        public float _x;
        public float _y;
        public int _width;
        public int _height;
        public bool _selected;

        public Shape()
        {
            _color = SplashKitSDK.Color.Green;
            _x = 0;
            _y = 0;
            _width = 100;
            _height = 100;
        }

        public void Draw()
        {
            if (Selected) { DrawOutline(); }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
        }

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }
        public int Height { get { return _height; } set { _height = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public SplashKitSDK.Color Color { get { return _color; } set { _color = value; } }
        public bool Selected { get { return _selected; } set { _selected = value; } }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }
    }
}