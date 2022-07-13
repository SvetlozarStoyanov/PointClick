using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClick.CustomElements.Buttons
{
    internal class ButtonBackground : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //this.Size = new Size(150, 150);
            Text = null;
            TabStop = false;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            base.OnPaint(pevent);
        }
        protected override void OnMouseHover(EventArgs e)
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            //base.OnMouseHover(e);
        }
    }
}
