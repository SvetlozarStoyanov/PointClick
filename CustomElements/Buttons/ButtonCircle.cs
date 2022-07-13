using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClick.CustomElements.Buttons
{
    internal class ButtonCircle : Button
    {
        private int sizeOfButton;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(graphicsPath);
            //this.Image = Image.FromFile(@"..\..\..\Graphics\RedScreen.jpg");


            Size = new Size(sizeOfButton, sizeOfButton);
            //this.Size = new Size(150, 150);
            ForeColor = Color.Red;
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
        public void SetSize(int size)
        {
            sizeOfButton = size;
        }
    }
}
