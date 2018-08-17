using System;
using System.IO;
using ObjectDetectionGui.Base;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using DeepLearning;

namespace Models
{
    public class ImageInfoModel : NotifiedModelBase
    {
        #region Fields

        private ImageSource m_ImgSrc; 
        private string m_ImageName;
        private string m_ImagePath;
        private int    m_ImageWidth;
        private int    m_ImageHeight;

        #endregion

        #region Initilizing

        public ImageInfoModel()
        {
        }

        public ImageInfoModel(string path)
        {
            ImagePath = path;
        }

        private void InitImageFileDetailes()
        {
           ImageName = Path.GetFileName(m_ImagePath);
           InitImageSize();
        }

        private void InitImageSize()
        {
            var imgSrc = new BitmapImage(new Uri(m_ImagePath, UriKind.Absolute));
            ImageWidth = imgSrc.PixelWidth;
            ImageHeight = imgSrc.PixelHeight;
            ImgSrc = imgSrc;
        }

        #endregion

        #region Properties

        public ImageSource ImgSrc
        {
            get { return m_ImgSrc; }
            set { SetProperty(ref m_ImgSrc, value); }
        }

        public string ImageName
        {
            get { return m_ImageName; }
            set { SetProperty(ref m_ImageName, value); }
        }   

        public string ImagePath
        {
            get { return m_ImagePath; }
            set
            {
                if (SetProperty(ref m_ImagePath, value))
                    InitImageFileDetailes();        
            }
        }

        public int ImageWidth
        {
            get { return m_ImageWidth; }
            set { SetProperty(ref m_ImageWidth, value); }
        }

        public int ImageHeight
        {
            get { return m_ImageHeight; }
            set { SetProperty(ref m_ImageHeight, value); }
        }

         #endregion
    }
}
