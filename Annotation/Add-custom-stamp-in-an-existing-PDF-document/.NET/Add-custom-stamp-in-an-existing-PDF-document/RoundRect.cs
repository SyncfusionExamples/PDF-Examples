using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_custom_stamp_in_an_existing_PDF_document
{
    public class RoundRect
    {
        public PdfPath RoundedRect(RectangleF bounds, int radius)
        {
            int diameter = radius * 2;
            SizeF size = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(bounds.Location, size);
            PdfPath path = new PdfPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            //Draw the top left arc  
            path.AddArc(arc, 180, 90);

            //Draw the top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            //Draw the bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            //Draw the bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            //Close the figure
            path.CloseFigure();

            //Return the path. 
            return path;
        }
    }
}
