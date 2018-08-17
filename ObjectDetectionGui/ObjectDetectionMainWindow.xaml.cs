using ObjectDetectionGui.Base;
using Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ObjectDetectionGui
{
    public partial class ObjectDetectionMainWindow : Window
    {
        private PreviewImageModel m_Model;

        public ObjectDetectionMainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            m_Model = PreviewImageModel.Instance;
            previewImageGrid.DataContext = m_Model;

            m_Model.MainImage = previweImage;
            m_Model.MainCanvas = previewCanvas;

            statusBarGrid.DataContext = WrapperModel.Instance;
        }
    }
}
