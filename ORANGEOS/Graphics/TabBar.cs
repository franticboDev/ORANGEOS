using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using System.Drawing;

namespace ORANGEOS.Graphics
{
    public class TabBar
    {
        private Pen pen;
        private Int32 rows, columns;

        public TabBar(Canvas canvas)
        {
            this.pen = new Pen(Color.White);
            this.rows = canvas.Mode.Rows;
            this.columns = canvas.Mode.Columns;

            canvas.DrawRectangle(this.pen, 0, this.rows - 100, this.columns - 2, 99);
            canvas.DrawRectangle(this.pen, 0, this.rows - 100, 100, 99);
            canvas.DrawLine(this.pen, 25, this.rows - 90, 75, this.rows - 10);
        }

        public void tryProcessTabBarClick(Int32 mouseX, Int32 mouseY)
        {
            if (new Rectangle(mouseX, mouseY, 1, 1).IntersectsWith(new Rectangle(0, this.rows - 100, 100, 99)))
                Console.Beep();
        }
    }
}
