using System.Collections.Generic;
using AndriiGro.ImageRecognition.KohonenSOM.Entities;

namespace AndriiGro.ImageRecognition.KohonenSOM.Services
{
    public class ObjectImageService
    {
        public void SaveObjectsToList()
        {
            
        }

        public void RecollectObjectsFromPixels(List<List<ImagePixel>> colorGroupList)
        {
            List<ObjectImage> objectsImages = new List<ObjectImage>();

            colorGroupList.ForEach(colorGroup =>
            {
                List<ObjectImage> objects = ConvertImagePixelsToObjects(colorGroup);
                objectsImages.AddRange(FindConnectionBetweenObjects(objects));
            });
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

        //get first -> search in cycle. Finished with first go to second and so on. Till 
        //no variants. So every object is separate 
        private List<ObjectImage> FindConnectionBetweenObjects(List<ObjectImage> objectImages)
        {
            bool isLastSearchForConnectionsSucceded = true;
            int processingObjectPosition = 0;
            bool isSearchForThisObjectFailed = false;

            for (int index = 0; index < objectImages.Count; index++)
            {
                
            }
            return objectImages;
        }
    }
}
