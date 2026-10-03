using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public abstract class Shape
    {
        private SplashKitSDK.Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        public Shape() : this(SplashKitSDK.Color.Yellow) { }

        public Shape(SplashKitSDK.Color clr)
        {
            _color = clr;
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }
        public SplashKitSDK.Color Color { get { return _color; } set { _color = value; } }
        public bool Selected { get { return _selected; } set { _selected = value; } }

        public abstract void DrawOutline();
    }
}

