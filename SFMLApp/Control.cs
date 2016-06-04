using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using SFML.Graphics;

namespace SFMLApp
{
    class Control
    {
        public View view { get; private set; }
        private int Width, Heigth;
        public Control(int Width, int Heigth)
        {
            this.Width = Width;
            this.Heigth = Heigth;
            view = new View(Width, Heigth);
            view.InitEvents(Close, KeyDown, MouseDown, MouseUp, MouseMove);
        }
        
        public void UpDate(long time)
        {
            view.Clear(Color.Black);
            view.DrawMenu();
            if (time > 0)
                view.DrawText((1000 / time).ToString(), 5, 5, 10, Fonts.Arial, Color.White);
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        public void MouseUp(object sender, MouseButtonEventArgs e)
        {
            view.MainForm.Size = new Vector2u(512, 372);
        }

        public void MouseMove(object sender, MouseMoveEventArgs e)
        {
        }

        public void Close(object send, EventArgs e)
        {
            ((RenderWindow)send).Close();
        }
    }
}
