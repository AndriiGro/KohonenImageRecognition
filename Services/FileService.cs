using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Services
{
    public class FileService
    {
        private readonly SettingsService _settingsService = new SettingsService();

        public string GetImageFilePath()
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                AddExtension = true,
                Multiselect = false,
                Filter = "JPEG images|*.jpg; *.jpeg; *.jpe; *.jif; *.jfif; *.jfi|" +
                        "Bitmap images|*.bmp|GIF images|*.gif|PNG images|" +
                        "*.png|TIFF images|*.tiff; *.tif|All files|*.*"
            };

            if (openFileDialog.ShowDialog() != true)
            {
                return null; 
            }

            string filePath = openFileDialog.FileName;

            return filePath;
        }

        public BitmapImage GetBitmapFromPath(string imagePath)
        {
            var imageToReturn = new BitmapImage();

            try
            {
                imageToReturn = new BitmapImage(new Uri(imagePath));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("There was an error during opening the image." +
                                "Please check the path.");
            }

            return imageToReturn;
        }

        public BitmapImage GetBitmapFileFromDisk()
        {
            return GetBitmapFromPath(GetImageFilePath());
        }

        public void SaveBitmapImageForRecognitionToParameters()
        {
            Parameters.LoadedBitmapImageToRecognize = GetBitmapFileFromDisk();
        }

        public BitmapImage GetKononenNetworkImageFromDefaultPath()
        {
            var networkImage = new BitmapImage();
            string pathToImage = Directory.GetCurrentDirectory() 
                + "\\" 
                + _settingsService.GetSettingValueByKey("PathToKohonenNetwork");

            try
            {
                networkImage = new BitmapImage(new Uri(pathToImage, UriKind.Absolute));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("There was an error during opening the image." +
                                "Please check the path.");
            }

            SaveKohonenNetworkImageToParameters(networkImage);

            return networkImage;
        }

        public void SaveKohonenNetworkImageToParameters(BitmapImage kohonenNetworkImage)
        {
            Parameters.CurrentKohonenNetworkImage = kohonenNetworkImage;
        }
    }
}
