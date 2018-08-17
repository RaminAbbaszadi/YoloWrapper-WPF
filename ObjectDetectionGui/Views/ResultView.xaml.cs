using System;
using System.Collections.Generic;
using System.Windows.Controls;
using DeepLearning;
using Models;

namespace ObjectDetectionGui.Views
{
    public partial class ResultView : UserControl
    {
        public ResultView()
        {
            InitializeComponent();
            ResultViewModel model = ResultViewModel.Instance;
            ResultsDataGrid.DataContext = model;
        }

        private void ResultsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultInfoModel resultModel = ResultsDataGrid.SelectedItem as ResultInfoModel;
            if (resultModel == null)
                return;

            DetectedItemInfo item = new DetectedItemInfo();
            item.Type = resultModel.DetectionLabel;
            item.Confidence = resultModel.Confidence;
            item.X = resultModel.DetectedBoxLeftTopX;
            item.Y = resultModel.DetectedBoxLeftTopY;
            item.Width = resultModel.DetectedBoxWidth;
            item.Height = resultModel.DetectedBoxHeight;

            PreviewImageModel previewModel = PreviewImageModel.Instance;
            previewModel.DrawDetectedBoundingBoxOnImage(item);
        }
    }
}
