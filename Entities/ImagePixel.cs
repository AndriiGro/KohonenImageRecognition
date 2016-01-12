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
        private Color _imagePixelColor;
        private Point _imagePixelPosition;

        public ImagePixel(Color imagePixelColor, Point imagePixelPosition)
        {
            _imagePixelColor = imagePixelColor;
            _imagePixelPosition = imagePixelPosition;
        }

        public ImagePixel(Color imagePixelColor, int xPosition, int yPosition)
        {
            _imagePixelColor = imagePixelColor;
            _imagePixelPosition = new Point(xPosition, yPosition);
        }
    }
}
