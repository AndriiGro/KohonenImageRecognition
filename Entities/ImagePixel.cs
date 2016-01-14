using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndriiGro.ImageRecognition.KohonenSOM.Entities
{
    public class ImagePixel
    {
        public Color ImagePixelColor { get; private set; }

        public Point ImagePixelPosition { get; private set; }

        public ImagePixel(Color imagePixelColor, Point imagePixelPosition)
        {
            ImagePixelColor = imagePixelColor;
            ImagePixelPosition = imagePixelPosition;
        }

        public ImagePixel(Color imagePixelColor, int xPosition, int yPosition)
        {
            ImagePixelColor = imagePixelColor;
            ImagePixelPosition = new Point(xPosition, yPosition);
        }


    }
}
