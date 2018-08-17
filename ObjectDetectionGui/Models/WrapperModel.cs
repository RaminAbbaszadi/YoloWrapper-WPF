using System.Linq;
using DeepLearning;
using System.Diagnostics;
using ObjectDetectionGui.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Models
{
    public class WrapperModel: NotifiedModelBase
    {
        #region Fields

        private static WrapperModel m_Instance = null;
        private string m_NetInitilizeElapsedTime;
        private string m_NetHardware;
        private string m_DetectionElapsedTime;
        private bool m_IsDetectionEnable = false;

        #endregion

        #region Initilizing

        private WrapperModel()
        {
            IsDetectionEnable = false;
            Task.Run(() => InitialNetwork());
        }

        private void InitialNetwork()
        {
            IsDetectionEnable = false;

            var sw = new Stopwatch();
            sw.Start();
            Wrapper = new DeepLearningWrapper();
            Wrapper.InitilizeDeepLearningNetwork();
            InitilizeHardware();
            sw.Stop();

            NetInitilizeElapsedTime = "Network Initilaized in " + sw.Elapsed.TotalMilliseconds.ToString("F2") + " ms";
            IsDetectionEnable = true;
        }

        private void InitilizeHardware()
        {
            switch (Wrapper.DetectionHardware)
            {
                case DeepLearning.Base.DetectionHardwares.CPU:
                    NetHardware = "Process in CPU";
                    break;
                case DeepLearning.Base.DetectionHardwares.GPU:
                    NetHardware = "Process in GPU";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Detection

        public List<DetectedItemInfo> Detect()
        {
            var sw = new Stopwatch();
            sw.Start();
            List<DetectedItemInfo> items;
            items = Wrapper.Detect(FilePath).ToList();
            sw.Stop();

            DetectionElapsedTime = "Image processed in " + sw.Elapsed.TotalMilliseconds.ToString("F2") + " ms";
            return items;
        }

        #endregion

        #region Properties

        public static WrapperModel Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new WrapperModel();
                return m_Instance;
            }
        }

        public string NetInitilizeElapsedTime
        {
            get { return m_NetInitilizeElapsedTime; }
            set { SetProperty(ref m_NetInitilizeElapsedTime, value);}
        }

        public string NetHardware
        {
            get { return m_NetHardware; }
            set { SetProperty(ref m_NetHardware, value);}
        }

        public string DetectionElapsedTime
        {
            get { return m_DetectionElapsedTime; }
            set { SetProperty(ref m_DetectionElapsedTime, value);}
        }

        public bool IsDetectionEnable
        {
            get { return m_IsDetectionEnable; }
            set { SetProperty(ref m_IsDetectionEnable, value);}
        }

        public DeepLearningWrapper Wrapper { get; private set; }
        public string FilePath { get; set; }

        #endregion
    }
}
