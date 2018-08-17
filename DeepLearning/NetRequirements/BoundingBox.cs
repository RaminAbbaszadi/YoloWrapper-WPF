using System;

namespace DeepLearning
{
    internal struct BoundingBox
    {
        #region Fields

        internal UInt32 leftTopX, leftTopY, width, height;
        internal float prob;
        internal UInt32 obj_id;
        internal UInt32 track_id;
        internal UInt32 frames_counter;
        
        #endregion
    }
}
