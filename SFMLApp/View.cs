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
    class View
    {
        public RenderWindow MainForm { get; private set; }
        private int Width, Heigth;
        Sprite Menu;

        public void InitEvents(EventHandler Close, EventHandler<KeyEventArgs> KeyDown, EventHandler<MouseButtonEventArgs> MouseDown, EventHandler<MouseButtonEventArgs> MouseUp, EventHandler<MouseMoveEventArgs> MouseMove)
        {
            MainForm.Closed += Close;
            MainForm.KeyPressed += KeyDown;
            MainForm.MouseButtonPressed += MouseDown;
            MainForm.MouseButtonReleased += MouseUp;
            MainForm.MouseMoved += MouseMove;
        }

        public View(int Width, int Heigth)
        {
            this.Width = Width;
            this.Heigth = Heigth;
            MainForm = new RenderWindow(new VideoMode((uint)Width, (uint)Heigth), "SFML.net", Styles.Titlebar | Styles.Close);            
            Menu = new Sprite(new Texture("data/Menu.png"));
            Menu.Position = new Vector2f(0, 0);
        }

        public void Clear()
        {
            MainForm.Clear(Color.White);
        }

        public void Clear(Color cl)
        {
            MainForm.Clear(cl);
        }

        public void DrawMenu()
        {
            MainForm.Draw(Menu);
        }

        public void DrawText(string s, int x, int y, int size, Font Font, Color cl)
        {
            Text TextOut = new Text(s, Font);
            TextOut.CharacterSize = (uint)size;
            TextOut.Color = cl;
            MainForm.Draw(TextOut);
        }
    }
}
