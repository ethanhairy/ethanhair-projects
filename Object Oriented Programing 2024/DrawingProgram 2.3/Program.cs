using System;
using SplashKitSDK;
using System.Text;

namespace DrawingProgram
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape();
            Window window = new Window("DrawingProgram", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    if (myShape.IsAt(SplashKit.MousePosition()))
                    {
                        myShape.Color = SplashKit.RandomRGBColor(255);
                    }
                }

                myShape.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
