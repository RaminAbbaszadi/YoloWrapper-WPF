using DeepLearning;
using System.Windows.Media;
using ObjectDetectionGui.Base;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Controls;
using System;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Models
{
    public class PreviewImageModel: NotifiedModelBase
    {

        #region Fields

        private ImageInfoModel m_ImageInfoModel;
        private ImageSource m_ImgSrc;
        private static PreviewImageModel m_Instance = null;

        #endregion

        #region Initilizing

        private PreviewImageModel()
        {
        }

        #endregion

        #region Drawing BoundingBox

        public void DrawDetectedBoundingBoxOnImage(DetectedItemInfo selectedItem = null)
        {
            var src = new BitmapImage(new Uri(m_ImageInfoModel.ImagePath, UriKind.Absolute));
            Pen pen;
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawImage(src, new Rect(0, 0, src.PixelWidth, src.PixelHeight));
                foreach (DetectedItemInfo item in DetectedItemInfoList)
                {
                    if (item.Compare(selectedItem))
                    {
                        pen = new Pen(Brushes.Green, 3);
                        var overLayBrush = new SolidColorBrush(Color.FromArgb(150, 255, 255, 102));
                        dc.DrawRectangle(overLayBrush, pen, new Rect(item.X, item.Y, item.Width, item.Height));
                    }
                    else
                    {
                        pen = new Pen(Brushes.Blue, 3);
                        dc.DrawRectangle(Brushes.Transparent, pen, new Rect(item.X, item.Y, item.Width, item.Height));
                    }
                }
            }

            RenderTargetBitmap rtb = new RenderTargetBitmap(src.PixelWidth, src.PixelHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);
            ImgSrc = rtb;
        }

        #endregion

        #region Properties

        public static PreviewImageModel Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new PreviewImageModel();

                return m_Instance;
            }
        }

        public ImageInfoModel ImgInfoModel
        {
            get { return m_ImageInfoModel; }
            set
            {
                if (SetProperty(ref m_ImageInfoModel, value))
                    ImgSrc = m_ImageInfoModel.ImgSrc;
            }
        }

        public ImageSource ImgSrc
        {
            get { return m_ImgSrc; }
            set { SetProperty(ref m_ImgSrc, value); }
        }

        public Image MainImage { get; set; }
        public Canvas MainCanvas { get; set; }
        public List<DetectedItemInfo> DetectedItemInfoList { get; set; }

        #endregion
    }
}
