using System.Collections.Generic;
using AndriiGro.ImageRecognition.KohonenSOM.Entities;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class ObjectImageService
    {
        private readonly ImageService _imageService = new ImageService();

        //convert to Bitmaps 
        public void SaveObjectsToParametersAsBitmaps(List<ObjectImage> objectImages)
        {
            Parameters.FoundObjectsImagesList = _imageService.ConvertObjectImagestoBitmaps(objectImages);
        }

        public List<ObjectImage> RecollectObjectsFromPixels(List<List<ImagePixel>> colorGroupList)
        {
            var objectsImages = new List<ObjectImage>();

            colorGroupList.ForEach(colorGroup =>
            {
                List<ObjectImage> objects = ConvertImagePixelsToObjects(colorGroup);

                while (true)
                {
                    bool isSearchSucceded = FindConnectionBetweenObjects(ref objects);

                    if (isSearchSucceded)
                    {
                        continue;
                    }

                    break;
                }

                objectsImages.AddRange(objects);
            });

            return objectsImages;
        }

        private List<ObjectImage> ConvertImagePixelsToObjects(List<ImagePixel> imagePixels)
        {
            var objectImages = new List<ObjectImage>();

            imagePixels.ForEach(pixel =>
            {
                objectImages.Add(new ObjectImage(pixel));
            });

            return objectImages;
        }
        
        private bool FindConnectionBetweenObjects(ref List<ObjectImage> objectImages)
        {
            bool canFindConnections = true;
            
            int processingObjectPosition = 0;
            bool isAnyConnectionFound = false;

            do
            {
                bool isLastSearchForConnectionsSucceded = false;

                for (int index = 0; index < objectImages.Count; index++)
                {
                    if(index == processingObjectPosition)
                    {
                        continue;
                    }

                    bool searchResult =
                        objectImages[index].CheckIfObjectAdjacentToThis(objectImages[processingObjectPosition]);

                    if (!searchResult)
                    {
                        continue;
                    }

                    objectImages[index].AddObjectImageToThis(objectImages[processingObjectPosition]);
                    objectImages.RemoveAt(processingObjectPosition);

                    isLastSearchForConnectionsSucceded = true;
                    isAnyConnectionFound = true;

                    break;
                }

                if (!isLastSearchForConnectionsSucceded)
                {
                    processingObjectPosition++;
                }

                if (processingObjectPosition == objectImages.Count)
                {
                    canFindConnections = false;
                }

            } while (canFindConnections);

            return isAnyConnectionFound;
        }
    }
}
