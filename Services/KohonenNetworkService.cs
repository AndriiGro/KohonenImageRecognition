using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AndriiGro.ImageRecognition.KohonenSOM.Entities;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class KohonenNetworkService
    {
        private readonly ObjectImageService _objectImageService = new ObjectImageService();

        public void GroupObjectsByColorFromImageToRecongnize()
        {
            List<Color> kohonenNetworkColorsList =
                GetColorsFromCurrentKohonenNetwork();
            List<List<ImagePixel>> colorGroupsList =
                GroupCurrentImagePixelsByColors(kohonenNetworkColorsList);
            colorGroupsList = FilterColorGroupsList(colorGroupsList);
            
            _objectImageService.SaveObjectsToParametersAsBitmaps(
                _objectImageService.RecollectObjectsFromPixels(colorGroupsList));
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

        public List<List<ImagePixel>> GroupCurrentImagePixelsByColors(List<Color> colorsList)
        {
            int maxColorGroupQuanity = Parameters.CurrentKohonenNetworkBitmap.Width*
                                       Parameters.CurrentKohonenNetworkBitmap.Height;
            var colorGroupsList = new List<List<ImagePixel>>();

            colorGroupsList.EnsureSize(maxColorGroupQuanity);

            for (int xPosition = 0; xPosition < Parameters.LoadedBitmapToRecognize.Width; xPosition++)
            {
                for (int yPosition = 0; yPosition < Parameters.LoadedBitmapToRecognize.Height; yPosition++)
                {
                    int numberOfColorList = FindBestMatchingColorPosition(
                        Parameters.LoadedBitmapToRecognize.GetPixel(xPosition, yPosition), colorsList);

                    colorGroupsList[numberOfColorList]
                        .Add(new ImagePixel(
                            Parameters.LoadedBitmapToRecognize.GetPixel(xPosition, yPosition),
                            xPosition,
                            yPosition));
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

                if (tempDistance > lowestEuclideanDistanceBetweenTwoColors)
                {
                    continue;
                }

                lowestEuclideanDistanceBetweenTwoColors = tempDistance;
                bestMatchingColorPositionInList = index;
            }

            return bestMatchingColorPositionInList;
        }

        public List<List<ImagePixel>> FilterColorGroupsList(List<List<ImagePixel>> colorGroupsList)
        {
            return colorGroupsList
                .Where(colorList =>
                colorList.Count >= ApplicationConsts.MinQuantityOfPixelsInGroup)
                .ToList();
        }
    }
}
