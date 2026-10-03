using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Drawing
    {
        private Color _background;
        private readonly List<Shape> _shapes;

        public Drawing() : this(Color.White) { }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> _selectedShapes = new List<Shape>();
            foreach (Shape s in _selectedShapes)
            {
                if (s.Selected) { _selectedShapes.Add(s); }
            }
            return _selectedShapes;
        }

        public Color Background { get { return _background; } set { _background = value; } }
        public int ShapeCount { get { return _shapes.Count; } }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(Background);

            foreach (Shape s in _shapes) { s.Draw(); }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt)) { s.Selected = true; }
                else { s.Selected = false; }
            }
        }

        public void RemoveShape()
        {
            foreach (Shape s in _shapes.ToList())
            {
                if (s.Selected) { _shapes.Remove(s); }
            }
        }
    }
}