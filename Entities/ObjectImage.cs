using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AndriiGro.ImageRecognition.KohonenSOM.Entities
{
    public class ObjectImage
    {
        public List<ImagePixel> ObjectPixelsList { get; private set; } =
            new List<ImagePixel>();
        
        private List<Point> ObjectPointsList { get; set;} = new List<Point>();

        public ObjectImage(ImagePixel firstObjectPixel)
        {
            ObjectPixelsList.Add(firstObjectPixel);
            UpdateObjectPointsList();
        }

        public bool CheckIfObjectAdjacentToThis(ObjectImage objectImage)
        {
            return objectImage.ObjectPixelsList.Any(CheckIfPixelAdjacentToThisObject);
        }

        public void AddObjectImageToThis(ObjectImage objectImage)
        {
            ObjectPixelsList.AddRange(objectImage.ObjectPixelsList);
            UpdateObjectPointsList();
        }

        private bool CheckIfPixelAdjacentToThisObject(ImagePixel imagePixel)
        {
            List<Point> surroundingPoints =
                GenerateSurroundingPointsOfPixel(imagePixel);

            return surroundingPoints.Any(p => ObjectPointsList.Contains(p));
        }

        private List<Point> ConverImagePixelsToPoints(List<ImagePixel> imagePixels)
        {
            return imagePixels.Select(pixel => pixel.ImagePixelPosition).ToList();
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

        private void UpdateObjectPointsList()
        {
            ObjectPointsList = ConverImagePixelsToPoints(ObjectPixelsList);
        }
    }
}
