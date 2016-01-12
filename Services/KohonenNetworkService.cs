using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class KohonenNetworkService
    {
        public void GroupObjectsByColorFromImageToRecongnize()
        {
            List<Color> kohonenNetworkColorsList =
                GetColorsFromCurrentKohonenNetwork();
            List<List<Color>> colorGroupsList =
                GroupCurrentImagePixelsByColorsList(kohonenNetworkColorsList);
            colorGroupsList = FilterColorGroupsList(colorGroupsList);

        }

        public List<Color> GetColorsFromCurrentKohonenNetwork()
        {
            var kohonenNetworkColorsList = new List<Color>();

            for (int xPosition = 0; xPosition < Parameters.CurrentKohonenNetworkBitmap.Width; xPosition++)
            {
                for (int yPosition = 0; yPosition < Parameters.CurrentKohonenNetworkBitmap.Height; yPosition++)
                {
                    Color color =
                        Parameters.CurrentKohonenNetworkBitmap.GetPixel(xPosition, yPosition);

                    if (!kohonenNetworkColorsList.Contains(color))
                    {
                        kohonenNetworkColorsList.Add(color);
                    }
                }
            }

            return kohonenNetworkColorsList;
        }

        public double GetEuclideanDistanceForTwoRgbColors(Color imageColor, Color networkColor)
        {
            double distance = 0;

            distance += (imageColor.R - networkColor.R) * (imageColor.R - networkColor.R);
            distance += (imageColor.G - networkColor.G) * (imageColor.G - networkColor.G);
            distance += (imageColor.B - networkColor.B) * (imageColor.B - networkColor.B);

            return Math.Sqrt(distance);
        }

        public List<List<Color>> GroupCurrentImagePixelsByColorsList(List<Color> colorsList)
        {
            var colorGroupsList = new List<List<Color>>();

            for (int xPosition = 0; xPosition < Parameters.LoadedBitmapToRecognize.Width; xPosition++)
            {
                for (int yPosition = 0; yPosition < Parameters.LoadedBitmapToRecognize.Height; yPosition++)
                {
                    int numberOfColorList = FindBestMatchingColorPosition(
                        Parameters.LoadedBitmapToRecognize.GetPixel(xPosition, yPosition), colorsList);

                    colorGroupsList[numberOfColorList]
                        .Add(Parameters.LoadedBitmapToRecognize.GetPixel(xPosition, yPosition));
                }
            }

            return colorGroupsList;
        }

        public int FindBestMatchingColorPosition(Color processingColor, List<Color> colorsList)
        {
            int bestMatchingColorPositionInList = 0;
            double lowestEuclideanDistanceBetweenTwoColors = double.MaxValue;

            for (int index = 0; index < colorsList.Count; index++)
            {
                var color = colorsList[index];
                double tempDistance = GetEuclideanDistanceForTwoRgbColors(processingColor, color);

                if (!(tempDistance < lowestEuclideanDistanceBetweenTwoColors))
                {
                    continue;
                }

                lowestEuclideanDistanceBetweenTwoColors = tempDistance;
                bestMatchingColorPositionInList = index;
            }

            return bestMatchingColorPositionInList;
        }

        public List<List<Color>> FilterColorGroupsList(List<List<Color>> colorGroupsList)
        {
            return colorGroupsList
                .Where(colorList =>
                colorList.Count >= ApplicationConsts.MIN_QUANTITY_OF_PIXELS_IN_GROUP)
                .ToList();
        }
    }
}
