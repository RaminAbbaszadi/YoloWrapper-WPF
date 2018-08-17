using ObjectDetectionGui.Base;

namespace Models
{
    public class ResultInfoModel : NotifiedModelBase
    {
        #region Fields

        private string m_DetectionLabel;
        private double m_Confidence;
        private int    m_DetectedBoxLeftTopX;

        private int m_DetectedBoxLeftTopY;
        private int m_DetectedBoxWidth;
        private int m_DetectedBoxHeight;

        #endregion

        #region Initilizing

        public ResultInfoModel()
        {
        }

        #endregion

        #region Properties

        public string DetectionLabel
        {
            get { return m_DetectionLabel; }
            set { SetProperty(ref m_DetectionLabel, value); }
        }

        public double Confidence
        {
            get { return m_Confidence; }
            set { SetProperty(ref m_Confidence, value); }
        }

        public int DetectedBoxLeftTopX
        {
            get { return m_DetectedBoxLeftTopX; }
            set { SetProperty(ref m_DetectedBoxLeftTopX, value); }
        }

        public int DetectedBoxLeftTopY
        {
            get { return m_DetectedBoxLeftTopY; }
            set { SetProperty(ref m_DetectedBoxLeftTopY, value); }
        }

        public int DetectedBoxWidth
        {
            get { return m_DetectedBoxWidth; }
            set { SetProperty(ref m_DetectedBoxWidth, value); }
        }

        public int DetectedBoxHeight
        {
            get { return m_DetectedBoxHeight; }
            set { SetProperty(ref m_DetectedBoxHeight, value); }
        }

        #endregion

    }
}
