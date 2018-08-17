namespace DeepLearning
{
    public class DetectedItemInfo
    {
        #region Properties

        public string Type { get; set; }
        public double Confidence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        #endregion

        #region Utilities

        public bool Compare(DetectedItemInfo newItem)
        {
            bool result = false;
            if (newItem != null)
            {
                if (newItem.Type == this.Type && newItem.Confidence == this.Confidence &&
                    newItem.X == this.X && newItem.Y == this.Y && newItem.Width == this.Width &&
                    newItem.Height == this.Height)
                {
                    result = true;
                }
            }
            return result;
        }

        #endregion
    }
}
