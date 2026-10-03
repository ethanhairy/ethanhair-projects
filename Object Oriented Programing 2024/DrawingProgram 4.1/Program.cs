using System;
using SplashKitSDK;
using System.Text;

namespace DrawingProgram
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing myDrawing = new Drawing();
            Window window = new Window("DrawingProgram", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey)) { kindToAdd = ShapeKind.Rectangle; }
                if (SplashKit.KeyTyped(KeyCode.CKey)) { kindToAdd = ShapeKind.Circle; }
                if (SplashKit.KeyTyped(KeyCode.LKey)) { kindToAdd = ShapeKind.Line; }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    myDrawing.RemoveShape();
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
