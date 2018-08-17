using DeepLearning;
using ObjectDetectionGui.Base;
using System;
using System.Collections.ObjectModel;

namespace Models
{
    public class ResultViewModel : NotifiedModelBase
    {
        private static ResultViewModel m_Instance = null;

        #region Initilizing

        private ResultViewModel()
        {
            ResultModelList = new ObservableCollection<ResultInfoModel>();
        }

        internal void ClearResultGrid()
        {
            ResultModelList.Clear();
            WrapperModel model = WrapperModel.Instance;
            model.DetectionElapsedTime = "";
        }

        #endregion

        #region Prperties

        public static ResultViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ResultViewModel();

                return m_Instance;
            }
        }

        public ObservableCollection<ResultInfoModel> ResultModelList { get; set; }

        #endregion
    }
}
