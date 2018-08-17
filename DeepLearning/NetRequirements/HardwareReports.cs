using System;
using System.IO;

namespace DeepLearning
{
    public class HardwareReports
    {
        #region Initilizing

        public HardwareReports()
        {
            Init();
        }

        private void Init()
        {
            if (File.Exists(@"x64\cudnn64_7.dll"))
               IsCudnnExists = true;

            var envirormentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            if (envirormentVariables.Contains("CUDA_PATH"))
                IsCudaExists = true;

        }

        #endregion

        #region Properties

        public bool IsCudaExists { get; set; }
        public bool IsCudnnExists { get; set; }
        public string GraphicDeviceName { get; set; }

        #endregion
    }
}
