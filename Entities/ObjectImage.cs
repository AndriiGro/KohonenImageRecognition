using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AndriiGro.ImageRecognition.KohonenSOM.Entities
{
    public class ObjectImage
    {
        public List<ImagePixel> ObjectPixelsList { get; private set; } =
            new List<ImagePixel>();

        public ObjectImage(ImagePixel firstObjectPixel)
        {
            ObjectPixelsList.Add(firstObjectPixel);
        }

        public bool CheckIfObjectAdjacentToThis(ObjectImage objectImage)
        {
            return false;
        }

        private bool CheckIfPixelAdjacentToThisObject(ImagePixel imagePixel)
        {

            return false;
        }

        private void AddObjectImageToThis(ObjectImage objectImage)
        {
            ObjectPixelsList.AddRange(objectImage.ObjectPixelsList);
        }

        private List<Point> GenerateSurroundingPointsOfPixel(ImagePixel imagePixel)
        {
            var surroundingPoints = new List<Point>();
            Point centre = imagePixel.ImagePixelPosition;

            //clockwise starting at top left
            surroundingPoints.Add(new Point((centre.X - 1), (centre.Y + 1)));
            surroundingPoints.Add(new Point((centre.X), (centre.Y + 1)));
            surroundingPoints.Add(new Point((centre.X + 1), (centre.Y + 1)));
            surroundingPoints.Add(new Point((centre.X + 1), (centre.Y)));
            surroundingPoints.Add(new Point((centre.X + 1), (centre.Y - 1)));
            surroundingPoints.Add(new Point((centre.X), (centre.Y - 1)));
            surroundingPoints.Add(new Point((centre.X - 1), (centre.Y - 1)));
            surroundingPoints.Add(new Point((centre.X - 1), (centre.Y)));

            return surroundingPoints;
        }
    }
}
