using System.Runtime.InteropServices;

namespace DeepLearning
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct BoundingBoxContainer
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DeepLearningWrapper.MAX_OBJECTS_NUMBER)]
        internal BoundingBox[] candidates;
    }
}
