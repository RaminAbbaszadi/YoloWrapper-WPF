namespace DeepLearning
{
    public class NetConfigaration
    {
        #region Const

        private const string CONFIG_FILE_PATH = @".\Assets\Cfg\yolov3.cfg";
        private const string WEIGHT_FILE_PATH = @".\Assets\Weights\yolov3.weights";
        private const string NAMES_FILE_PATH  = @".\Assets\Data\coco.names";

        #endregion

        #region Initilizing

        public NetConfigaration()
        {
            Init();
        }

        private void Init()
        {
            ConfigFile = CONFIG_FILE_PATH;
            Weightfile = WEIGHT_FILE_PATH;
            NamesFile  = NAMES_FILE_PATH;
        }

        #endregion

        #region Properties

        public string ConfigFile { get; set; }
        public string Weightfile { get; set; }
        public string NamesFile { get; set; }

        #endregion
    }
}
