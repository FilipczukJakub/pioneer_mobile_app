using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaInzynierska.CustomElements
{
    public class CustonButton : Button
    {
        public event EventHandler Pressed;
        public event EventHandler Released;
        public CustonButton()
        {
            BackgroundColor = Color.Blue;
            TextColor = Color.Black;
        }

        public virtual void OnPressed()
        { 
            Pressed?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnReleased()
        {
            Released?.Invoke(this, EventArgs.Empty);
        }
    }
}
