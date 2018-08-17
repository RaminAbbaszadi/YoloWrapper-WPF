using System;
using System.Windows;
using System.Windows.Controls;
using Models;
using DeepLearning;
using ObjectDetectionGui.Base;
using System.Collections.Generic;

namespace ObjectDetectionGui.Views
{
    public partial class BrowserView : UserControl
    {

        #region Fields

        private ResultViewModel m_ResultViewModel = ResultViewModel.Instance;
        private BrowserViweModel m_BrowseViewModel = BrowserViweModel.Instance;
        private PreviewImageModel m_PreviewImageModel = PreviewImageModel.Instance;

        #endregion

        #region Initializing

        public BrowserView()
        {
            InitializeComponent();
            FileBrowseGrid.DataContext = BrowserViweModel.Instance;
            SetBinding();
        }

        private void SetBinding()
        {
            DpUtil.SetBinding(WrapperModel.Instance, "IsDetectionEnable", DetectBt, Button.IsEnabledProperty);
        }

        #endregion

        #region Commands

        private void BrowseImageFilesBt_Click(object sender, RoutedEventArgs e)
        {
            m_BrowseViewModel.BrowseFiles();
            FileBrowseGrid.SelectedItem = FileBrowseGrid.Items[0];
        }

        private void DetectBt_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePath !=null)
            {
                WrapperModel model = WrapperModel.Instance;
                model.FilePath = ImagePath;
                List<DetectedItemInfo> items = new List<DetectedItemInfo>();
                items = model.Detect();
                SetDetectedItemsToBindableItems(items);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please select an image.", "Image not found.",
                                          MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion
        
        #region Utilitis

        private void SetDetectedItemsToBindableItems(List<DetectedItemInfo> items)
        {
            m_ResultViewModel.ResultModelList.Clear();
            foreach (DetectedItemInfo item in items)
            {
                ResultInfoModel resultModel = new ResultInfoModel();
                resultModel.DetectionLabel = item.Type;
                resultModel.Confidence = item.Confidence;
                resultModel.DetectedBoxLeftTopX = item.X;
                resultModel.DetectedBoxLeftTopY = item.Y;
                resultModel.DetectedBoxWidth = item.Width;
                resultModel.DetectedBoxHeight = item.Height;
                m_ResultViewModel.ResultModelList.Add(resultModel);
            }
            DrawBoundingBox(items);
        }

        private void DrawBoundingBox(List<DetectedItemInfo> items)
        {
            m_PreviewImageModel.DetectedItemInfoList = items;
            m_PreviewImageModel.DrawDetectedBoundingBoxOnImage();
        }

        #endregion

        #region Changed Value

        private void FileBrowseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageInfoModel imageModel = FileBrowseGrid.SelectedItem as ImageInfoModel;
            if (imageModel == null)
                return;

            ImagePath = imageModel.ImagePath;

            m_PreviewImageModel.ImgInfoModel = imageModel;
            m_ResultViewModel.ClearResultGrid();
        }

        #endregion

        private string ImagePath { get; set; }
    }
}
