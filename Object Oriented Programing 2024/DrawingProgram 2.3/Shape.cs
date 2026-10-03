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
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
        }

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }
        public SplashKitSDK.Color Color { get { return _color; } set { _color = value; } }

    }
}

